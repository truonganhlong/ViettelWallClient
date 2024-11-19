using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViettelWallClientNet8.Custom;
using ViettelWallClientNet8.Interface.Setting;
using ViettelWallClientNet8.Model.Camera;
using ViettelWallClientNet8.Model.Setting;
using ViettelWallClientNet8.Service.Setting;
using ViettelWallClientNet8.Util.Const;

namespace ViettelWallClientNet8.UserCtrl.Live
{
    public partial class LiveLeftLayoutTabUserCtrl : UserControl
    {
        private float original_width;
        private float original_height;
        private bool isShiftKeyPress;
        //interface
        private readonly ISettingLayoutService _settingLayoutService;
        //list layout expand
        private List<bool> isExpandList = new List<bool>();
        public LiveLeftLayoutTabUserCtrl()
        {
            _settingLayoutService = new SettingLayoutService();
            updateIsExpandList();
            InitializeComponent();
            InitializeAfter();
            InitializeSettingLayoutList();
        }

        private void InitializeAfter()
        {
            Panel titlePanel = new Panel();
            titlePanel.Height = 45;
            titlePanel.Dock = DockStyle.Top;
            titlePanel.BackColor = Color.FromArgb(64, 64, 64);
            titlePanel.Padding = new Padding(0, 10, 0, 10);
            //titlePanel.
            //titlePanel.FlowDirection = FlowDirection.LeftToRight; // Các control xếp ngang
            //titlePanel.WrapContents = false; // Không xuống dòng khi hết chiều rộng

            Label titleLabel = new Label();
            titleLabel.Text = "Riêng tư";
            titleLabel.Dock = DockStyle.Left;
            titleLabel.Size = new Size(60, 45);
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;
            titleLabel.Font = new Font(ApplicationConst.font_family_name, 9, FontStyle.Regular);
            titleLabel.ForeColor = Color.White;
            titleLabel.BackColor = Color.FromArgb(64, 64, 64);

            ToggleButton toggleButton = new ToggleButton();
            toggleButton.Anchor = AnchorStyles.Left;
            toggleButton.Size = new Size(35, 15);
            toggleButton.Location = new Point(55, 16);
            
            Button createButton = new Button();
            createButton.BackColor = Color.FromArgb(189, 53, 55);
            createButton.Dock = DockStyle.Right;
            createButton.Width = (int)(80 * returnWidthSizeRatio());
            createButton.Text = "+  Tạo mới";
            createButton.ForeColor = Color.White;
            createButton.FlatStyle = FlatStyle.Flat;
            createButton.FlatAppearance.BorderSize = 0;
            createButton.Click += createLayoutClick;

            titlePanel.Controls.Add(toggleButton);
            titlePanel.Controls.Add(titleLabel);
            titlePanel.Controls.Add(createButton);


            SearchIconTextBox searchTextBox = new SearchIconTextBox("Tìm kiếm Layouts, camera,...", returnHeightSizeRatio());
            searchTextBox.Dock = DockStyle.Top;

            top_content.Controls.Add(searchTextBox);
            top_content.Controls.Add(titlePanel);



            main_content_panel.AutoScroll = false;
            main_content_panel.HorizontalScroll.Maximum = 0;
            main_content_panel.VerticalScroll.Maximum = 0;
            main_content_panel.AutoScroll = true;
            //doi size live_left_camera_flp

            live_left_layout_flp.Size = new Size(main_content_panel.Width - 2, main_content_panel.Height - 2);
        }

        private void InitializeSettingLayoutList()
        {
            List<SettingLayout>? settingLayouts = _settingLayoutService.getAllSettingLayout();
            if (settingLayouts != null)
            {
                int liveLeftLayoutFlpHeight = 0;
                int tagTriangleIcon = 0;
                foreach (SettingLayout settingLayout in settingLayouts)
                {
                    Panel titlePanel = new Panel();
                    //titlePanel.Height = 30;
                    titlePanel.BackColor = Color.FromArgb(64, 64, 64);
                    titlePanel.Paint += settingLayoutListBorderPaint;
                    titlePanel.Padding = new Padding(0, 1, 0, 1);
                    titlePanel.Margin = new Padding(0, 3, 0, 0);
                    titlePanel.AutoSize = false;
                    titlePanel.Size = new Size(live_left_layout_flp.Width, (int)(30 * returnHeightSizeRatio()));
                    //titlePanel.Dock = DockStyle.Top;

                    PictureBox triangle_icon = new PictureBox();
                    triangle_icon.Size = new Size(16, 16);
                    triangle_icon.SizeMode = PictureBoxSizeMode.AutoSize;
                    if (isExpandList[tagTriangleIcon])
                    {
                        triangle_icon.Image = Properties.Resources.down_triangle_icon;
                    }
                    else
                    {
                        triangle_icon.Image = Properties.Resources.right_triangle_icon;
                    }
                    triangle_icon.Dock = DockStyle.Left;
                    triangle_icon.Padding = new Padding(0, 0, 7, 0);
                    triangle_icon.Tag = tagTriangleIcon;
                    triangle_icon.Click += triangleIconClick;

                    Panel layout_content_panel = new Panel();
                    layout_content_panel.Dock = DockStyle.Fill;
                    layout_content_panel.BackColor = Color.FromArgb(64, 64, 64);
                    Panel layout_top_content_panel = new Panel();
                    layout_top_content_panel.Height = 16;
                    layout_top_content_panel.Margin = new Padding(0);
                    layout_top_content_panel.Dock = DockStyle.Top;
                    Panel layout_bot_content_panel = new Panel();
                    layout_bot_content_panel.Margin = new Padding(0);
                    layout_bot_content_panel.Dock = DockStyle.Top;


                    PictureBox layout_icon = new PictureBox();
                    layout_icon.Size = new Size(16, 16);
                    layout_icon.SizeMode = PictureBoxSizeMode.AutoSize;
                    layout_icon.Image = Properties.Resources.layout_icon;
                    layout_icon.Dock = DockStyle.Left;

                    Label layout_name = new Label();
                    layout_name.AutoSize = false;
                    layout_name.Dock = DockStyle.Fill;
                    layout_name.Text = settingLayout.name;
                    layout_name.Font = new Font(ApplicationConst.font_family_name, 8 * returnMinSizeRatio());
                    layout_name.ForeColor = Color.White;
                    layout_name.BackColor = Color.FromArgb(64, 64, 64);

                    Label layout_shared_by = new Label();
                    layout_shared_by.AutoSize = false;
                    layout_shared_by.Dock = DockStyle.Fill;
                    layout_shared_by.Text = "Chia sẻ bởi: " + settingLayout.sharedBy;
                    layout_shared_by.Font = new Font(ApplicationConst.font_family_name, 6 * returnMinSizeRatio());
                    layout_shared_by.ForeColor = Color.White;
                    layout_shared_by.BackColor = Color.FromArgb(64, 64, 64);

                    layout_top_content_panel.Controls.Add(layout_name);
                    layout_top_content_panel.Controls.Add(layout_icon);
                    layout_bot_content_panel.Controls.Add(layout_shared_by);
                    layout_content_panel.Controls.Add(layout_bot_content_panel);
                    layout_content_panel.Controls.Add(layout_top_content_panel);

                    Label camera_count = new Label();
                    camera_count.AutoSize = false;
                    camera_count.Dock = DockStyle.Right;
                    camera_count.Width = (int)(60 * returnWidthSizeRatio());
                    if (settingLayout.listCameras != null)
                    {
                        camera_count.Text = settingLayout.listCameras.Count + " cameras ";
                    }
                    else {
                        camera_count.Text = "0 cameras ";
                    }
                    camera_count.Font = new Font(ApplicationConst.font_family_name, 7 * returnMinSizeRatio());
                    camera_count.ForeColor = Color.White;
                    camera_count.BackColor = Color.FromArgb(64, 64, 64);
                    camera_count.TextAlign = ContentAlignment.TopRight;

                    titlePanel.Controls.Add(camera_count);
                    //titlePanel.Controls.Add(layout_name);
                    //titlePanel.Controls.Add(layout_icon);
                    titlePanel.Controls.Add(layout_content_panel);
                    titlePanel.Controls.Add(triangle_icon);
                    live_left_layout_flp.Controls.Add(titlePanel);
                    liveLeftLayoutFlpHeight += 3 + (int)(30 * returnHeightSizeRatio());

                    if (isExpandList[tagTriangleIcon])
                    {
                        if (settingLayout.listCameras != null && settingLayout.listCameras.Count > 0)
                        {
                            foreach (CameraInLayout cameraInLayout in settingLayout.listCameras)
                            {
                                Panel subTitlePanel = new Panel();
                                subTitlePanel.BackColor = Color.FromArgb(64, 64, 64);
                                subTitlePanel.Paint += settingLayoutBorderPaint;
                                subTitlePanel.Padding = new Padding(0, 1, 0, 1);
                                subTitlePanel.AutoSize = false;
                                subTitlePanel.Size = new Size(live_left_layout_flp.Width - 55, (int)(30 * returnHeightSizeRatio()));
                                subTitlePanel.Anchor = AnchorStyles.Right | AnchorStyles.Top;
                                subTitlePanel.Margin = new Padding(0, 0, 10, 0);
                                subTitlePanel.Tag = cameraInLayout.cameraLink;
                                subTitlePanel.MouseEnter += cameraMouseEnter;
                                subTitlePanel.MouseLeave += cameraMouseLeave;
                                subTitlePanel.Click += cameraClick;
                                subTitlePanel.DoubleClick += cameraDoubleClick;

                                PictureBox camera_icon = new PictureBox();
                                camera_icon.Size = new Size(16, 16);
                                camera_icon.SizeMode = PictureBoxSizeMode.AutoSize;
                                camera_icon.Image = Properties.Resources.camera_icon;
                                camera_icon.Dock = DockStyle.Left;
                                camera_icon.BackColor = Color.Transparent;
                                camera_icon.MouseEnter += (s, e) => cameraMouseEnter(subTitlePanel, e);
                                camera_icon.MouseLeave += (s, e) => cameraMouseLeave(subTitlePanel, e);
                                camera_icon.Click += (s, e) => cameraClick(subTitlePanel, e);
                                camera_icon.DoubleClick += (s, e) => cameraDoubleClick(subTitlePanel, e);

                                Label camera_name = new Label();
                                camera_name.AutoSize = false;
                                camera_name.Dock = DockStyle.Fill;
                                camera_name.Text = cameraInLayout.cameraName;
                                camera_name.Font = new Font(ApplicationConst.font_family_name, 10 * returnMinSizeRatio());
                                camera_name.ForeColor = Color.White;
                                camera_name.BackColor = Color.Transparent;
                                camera_name.TextAlign = ContentAlignment.MiddleLeft;
                                camera_name.MouseEnter += (s, e) => cameraMouseEnter(subTitlePanel, e);
                                camera_name.MouseLeave += (s, e) => cameraMouseLeave(subTitlePanel, e);
                                camera_name.Click += (s, e) => cameraClick(subTitlePanel, e);
                                camera_name.DoubleClick += (s, e) => cameraDoubleClick(subTitlePanel, e);

                                subTitlePanel.Controls.Add(camera_name);
                                subTitlePanel.Controls.Add(camera_icon);
                                live_left_layout_flp.Controls.Add(subTitlePanel);
                                liveLeftLayoutFlpHeight += (int)(30 * returnHeightSizeRatio());
                            }
                        }
                    }
                    tagTriangleIcon++;
                }
                if (liveLeftLayoutFlpHeight > live_left_layout_flp.Height)
                {
                    live_left_layout_flp.Height = liveLeftLayoutFlpHeight;
                }
            }
        }

        private void createLayoutClick(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void settingLayoutListBorderPaint(object? sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            Graphics g = e.Graphics;

            using (Pen pen = new Pen(Color.FromArgb(47, 47, 47), ApplicationConst.border_thickness))
            {
                //g.DrawLine(pen, 0, 0, panel.Width, 0);

                g.DrawLine(pen, 0, panel.Height - 1, panel.Width - 10, panel.Height - 1);
            }
        }

        private void cameraDoubleClick(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void cameraClick(object? sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.BackColor = Color.FromArgb(212, 171, 178);
        }

        private void cameraMouseLeave(object? sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void cameraMouseEnter(object? sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.BackColor = Color.FromArgb(212, 171, 178);
        }

        private void triangleIconClick(object? sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            int tagValue = (int)pictureBox.Tag;
            if (IsSameImage(pictureBox.Image, Properties.Resources.right_triangle_icon))
            {
                pictureBox.Image = Properties.Resources.down_triangle_icon;
                isExpandList[tagValue] = true;
            }
            else if (IsSameImage(pictureBox.Image, Properties.Resources.down_triangle_icon))
            {
                pictureBox.Image = Properties.Resources.right_triangle_icon;
                isExpandList[tagValue] = false;
            }
            pictureBox.Refresh();
            live_left_layout_flp.Controls.Clear();
            InitializeSettingLayoutList();
        }

        private void settingLayoutBorderPaint(object? sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            Graphics g = e.Graphics;

            using (Pen pen = new Pen(Color.FromArgb(47, 47, 47), ApplicationConst.border_thickness))
            {
                //g.DrawLine(pen, 0, 0, panel.Width, 0);

                g.DrawLine(pen, 0, panel.Height - 1, panel.Width, panel.Height - 1);
            }
        }

        private void updateIsExpandList()
        {
            List<SettingLayout>? settingLayoutList = _settingLayoutService.getAllSettingLayout();
            if (settingLayoutList != null && settingLayoutList.Count > 0)
            {
                for (int i = 0; i < settingLayoutList.Count; i++)
                {
                    isExpandList.Add(false);
                }
            }
        }

        private void load(object sender, EventArgs e)
        {
            original_width = this.ClientSize.Width;
            original_height = this.ClientSize.Height;
        }

        private void keydown(object sender, KeyEventArgs e)
        {

        }

        private void keyup(object sender, KeyEventArgs e)
        {

        }

        private void resize(object sender, EventArgs e)
        {
            top_content.Controls.Clear();
            live_left_layout_flp.Controls.Clear();
            InitializeAfter();
            InitializeSettingLayoutList();
        }

        private bool IsSameImage(Image img1, Image img2)
        {
            // Kiểm tra nếu cả hai ảnh đều null
            if (img1 == null && img2 == null)
                return true;

            // Kiểm tra nếu một trong hai ảnh là null
            if (img1 == null || img2 == null)
                return false;

            using (MemoryStream ms1 = new MemoryStream())
            using (MemoryStream ms2 = new MemoryStream())
            {
                img1.Save(ms1, img1.RawFormat);
                img2.Save(ms2, img2.RawFormat);

                byte[] img1Bytes = ms1.ToArray();
                byte[] img2Bytes = ms2.ToArray();

                // So sánh hai mảng byte
                return img1Bytes.SequenceEqual(img2Bytes);
            }
        }

        private float returnMinSizeRatio()
        {
            if (this.ClientSize.Width == 0 || this.ClientSize.Height == 0 || original_width == 0 || original_height == 0)
            {
                return 1;
            }
            float widthRatio = (float)this.ClientSize.Width / original_width;
            float heightRatio = (float)this.ClientSize.Height / original_height;
            return Math.Min(widthRatio, heightRatio);
        }

        private float returnWidthSizeRatio()
        {
            if (this.ClientSize.Width == 0 || this.ClientSize.Height == 0 || original_width == 0 || original_height == 0)
            {
                return 1;
            }
            return (float)this.ClientSize.Width / original_width;
        }

        private float returnHeightSizeRatio()
        {
            if (this.ClientSize.Width == 0 || this.ClientSize.Height == 0 || original_width == 0 || original_height == 0)
            {
                return 1;
            }
            return (float)this.ClientSize.Height / original_height;
        }
    }
}
