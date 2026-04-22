using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Admin_Backup_Restore : Form
    {
        public Admin_Backup_Restore()
        {
            InitializeComponent();
        }

        private async Task RunMongoCommandAsync(string command)
        {
            await Task.Run(async () =>
            {
                var psi = new ProcessStartInfo("cmd.exe", "/c " + command)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = new Process())
                {
                    process.StartInfo = psi;
                    process.OutputDataReceived += (s, e) =>
                    {
                        if (!string.IsNullOrWhiteSpace(e.Data))
                            lstLog.Invoke(new Action(() => lstLog.Items.Add($"[OUT] {e.Data}")));
                    };
                    process.ErrorDataReceived += (s, e) =>
                    {
                        if (!string.IsNullOrWhiteSpace(e.Data))
                            lstLog.Invoke(new Action(() => lstLog.Items.Add($"[ERR] {e.Data}")));
                    };

                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    await Task.Run(() => process.WaitForExit());  // chờ tiến trình kết thúc

                    // ✅ Chỉ ném lỗi nếu thật sự thất bại
                    if (process.ExitCode != 0)
                        throw new Exception($"Mongo command failed (ExitCode={process.ExitCode})");
                }
            });
        }








        private async void btnBackup_Click(object sender, EventArgs e)

        {
            try
            {
                string backupPath = txtBackupPath.Text.Trim();

                // ✅ Kiểm tra đường dẫn có hợp lệ không
                if (string.IsNullOrEmpty(backupPath) || !Directory.Exists(backupPath))
                {
                    MessageBox.Show(
                        "⚠️ Đường dẫn trống hoặc không hợp lệ.\nVui lòng chọn thư mục để lưu bản sao lưu!",
                        "Thiếu thông tin",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                string folderName = "Backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string fullPath = Path.Combine(backupPath, folderName);

                Directory.CreateDirectory(fullPath);

                string command = $"mongodump --db GiaoNhanBuuPham --out \"{fullPath}\"";
                await RunMongoCommandAsync(command);

                MessageBox.Show(
                    $"✅ Sao lưu thành công!\nĐường dẫn: {fullPath}",
                    "Hoàn tất",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"❌ Lỗi khi sao lưu: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

        }

        private async void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                string restoreRoot = txtRestorePath.Text.Trim();

                // ✅ 1) Bắt buộc chọn thư mục tồn tại
                if (string.IsNullOrEmpty(restoreRoot) || !Directory.Exists(restoreRoot))
                {
                    MessageBox.Show(
                        "⚠️ Đường dẫn trống hoặc không hợp lệ.\nVui lòng chọn thư mục chứa bản sao lưu!",
                        "Thiếu thông tin",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    txtRestorePath.Focus();
                    return;
                }

                // ✅ 2) Kiểm tra đúng cấu trúc mongodump: <restoreRoot>\GiaoNhanBuuPham\*.bson
                string dbFolder = Path.Combine(restoreRoot, "GiaoNhanBuuPham");
                if (!Directory.Exists(dbFolder))
                {
                    MessageBox.Show(
                        "⚠️ Không tìm thấy thư mục con 'GiaoNhanBuuPham' trong thư mục đã chọn.\n" +
                        "Hãy chọn đúng thư mục gốc do mongodump tạo (ví dụ: Backup_YYYYMMDD_HHMMSS).",
                        "Sai thư mục",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    txtRestorePath.Focus();
                    return;
                }

                // ✅ 3) Thực thi mongorestore
                string command = $"mongorestore --drop --db GiaoNhanBuuPham \"{dbFolder}\"";
                await RunMongoCommandAsync(command);

                MessageBox.Show(
                    $"♻️ Phục hồi dữ liệu thành công từ:\n{restoreRoot}",
                    "Hoàn tất",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"❌ Lỗi khi phục hồi: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnBrowseBackup_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtBackupPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnBrowseRestore_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtRestorePath.Text = fbd.SelectedPath;
                }
            }
        }

        private void Admin_Backup_Restore_Load(object sender, EventArgs e)
        {

        }

        private void lstLog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
