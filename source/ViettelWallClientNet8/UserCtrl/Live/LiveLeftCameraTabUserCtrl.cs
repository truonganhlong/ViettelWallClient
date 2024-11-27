using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViettelWallClientNet8.Custom;
using ViettelWallClientNet8.Interface.Camera;
using ViettelWallClientNet8.Model.Camera;
using ViettelWallClientNet8.Service.Camera;
using ViettelWallClientNet8.Util.Const;

namespace ViettelWallClientNet8.UserCtrl.Live
{

    public partial class LiveLeftCameraTabUserCtrl : UserControl
    {
        private float original_width;
        private float original_height;
        //private int? firstSelectedIndex = null;
        public bool isShiftKeyPress = false;
        public bool isCtrlKeyPress = false;
        //interface
        private readonly ICameraService _cameraService;
        //list camera group expand
        private List<bool> isExpandList = new List<bool>();
        private SearchIconTextBox searchTextBox;

        private List<Panel> chosenCameras = new List<Panel>();
        private List<Panel> cameraPanelList = new List<Panel>();

        // event
        public event Action<string> sendLinkDoubleClick;        
        public LiveLeftCameraTabUserCtrl()
        {
            _cameraService = new CameraService();
            updateIsExpandList();
            InitializeComponent();
            InitializeAfter();
            InitializeCameraGroup();
        }

        private void InitializeAfter()
        {
            Label titleLabel = new Label();
            titleLabel.Text = "Danh sách camera";
            titleLabel.Height = 30;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;
            titleLabel.Font = new Font(ApplicationConst.font_family_name, 9, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.BackColor = Color.FromArgb(64, 64, 64);


            searchTextBox = new SearchIconTextBox("Nhập tên camera...", returnHeightSizeRatio());
            searchTextBox.Dock = DockStyle.Top;
            searchTextBox.textBox.TextChanged += searchFunction;

            top_content.Controls.Add(searchTextBox);
            top_content.Controls.Add(titleLabel);



            main_content_panel.AutoScroll = false;
            main_content_panel.HorizontalScroll.Maximum = 0;
            main_content_panel.VerticalScroll.Maximum = 0;
            main_content_panel.AutoScroll = true;
            //doi size live_left_camera_flp

            live_left_camera_flp.Size = new Size(main_content_panel.Width - 2, main_content_panel.Height - 2);
        }
        

        private void InitializeCameraGroup()
        {
            List<CameraGroup> cameraGroups = new List<CameraGroup>();
            if (searchTextBox.isPlaceHolder)
            {
                cameraGroups = _cameraService.getListCameraGroup(null);
            } else
            {
                cameraGroups = _cameraService.getListCameraGroup(searchTextBox.Text.Trim());
            }
            //List<CameraGroup> cameraGroups = _cameraService.getListCameraGroup();
            if (cameraGroups != null)
            {
                int liveLeftCameraFlpHeight = 0;
                int tagTriangleIcon = 0;
                foreach (CameraGroup cameraGroup in cameraGroups)
                {
                    Panel titlePanel = new Panel();
                    //titlePanel.Height = 30;
                    titlePanel.BackColor = Color.FromArgb(64, 64, 64);
                    titlePanel.Paint += cameraGroupBorderPaint;
                    titlePanel.Padding = new Padding(0, 1, 0, 1);
                    titlePanel.Margin = new Padding(0, 3, 0, 0);
                    titlePanel.AutoSize = false;
                    titlePanel.Size = new Size(live_left_camera_flp.Width, (int)(30 * returnHeightSizeRatio()));
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
                    triangle_icon.MouseClick += triangleIconClick;

                    PictureBox store_icon = new PictureBox();
                    store_icon.Size = new Size(16, 16);
                    store_icon.SizeMode = PictureBoxSizeMode.AutoSize;
                    store_icon.Image = Properties.Resources.store_icon;
                    store_icon.Dock = DockStyle.Left;

                    Label store_name = new Label();
                    store_name.AutoSize = false;
                    store_name.Dock = DockStyle.Fill;
                    store_name.Text = cameraGroup.groupName;
                    store_name.Font = new Font(ApplicationConst.font_family_name, 10);
                    store_name.ForeColor = Color.White;
                    store_name.BackColor = Color.FromArgb(64, 64, 64);

                    titlePanel.Controls.Add(store_name);
                    titlePanel.Controls.Add(store_icon);
                    titlePanel.Controls.Add(triangle_icon);
                    live_left_camera_flp.Controls.Add(titlePanel);
                    liveLeftCameraFlpHeight += 3 + (int)(30 * returnHeightSizeRatio());

                    if (isExpandList[tagTriangleIcon])
                    {
                        if (cameraGroup.listCameras != null && cameraGroup.listCameras.Count > 0)
                        {
                            int subTitlePanelIndex = 1;
                            foreach (Camera camera in cameraGroup.listCameras)
                            {
                                Panel subTitlePanel = new Panel();
                                subTitlePanel.Name = "subTitlePanel" + subTitlePanelIndex;
                                subTitlePanel.BackColor = Color.FromArgb(64, 64, 64);
                                subTitlePanel.Paint += cameraBorderPaint;
                                subTitlePanel.Padding = new Padding(0, 1, 0, 1);
                                subTitlePanel.AutoSize = false;
                                subTitlePanel.Size = new Size(live_left_camera_flp.Width - 55, (int)(30 * returnHeightSizeRatio()));
                                subTitlePanel.Anchor = AnchorStyles.Right | AnchorStyles.Top;
                                subTitlePanel.Margin = new Padding(0, 0, 10, 0);
                                subTitlePanel.Tag = camera.cameraLink;
                                subTitlePanel.MouseEnter += cameraMouseEnter;
                                subTitlePanel.MouseLeave += cameraMouseLeave;
                                subTitlePanel.MouseClick += cameraClick;
                                subTitlePanel.MouseDoubleClick += cameraDoubleClick;
                                subTitlePanel.MouseDown += cameraMouseDown;
                                cameraPanelList.Add(subTitlePanel);
                                subTitlePanelIndex++;

                                PictureBox camera_icon = new PictureBox();
                                camera_icon.Size = new Size(16, 16);
                                camera_icon.SizeMode = PictureBoxSizeMode.AutoSize;
                                camera_icon.Image = Properties.Resources.camera_icon;
                                camera_icon.Dock = DockStyle.Left;
                                camera_icon.BackColor = Color.Transparent;
                                camera_icon.MouseEnter += (s, e) => cameraMouseEnter(subTitlePanel, e);
                                camera_icon.MouseLeave += (s, e) => cameraMouseLeave(subTitlePanel, e);
                                camera_icon.MouseClick += (s, e) => cameraClick(subTitlePanel, e);
                                camera_icon.MouseDoubleClick += (s, e) => cameraDoubleClick(subTitlePanel, e);
                                camera_icon.MouseDown += (s, e) => cameraMouseDown(subTitlePanel, e);

                                Label camera_name = new Label();
                                camera_name.AutoSize = false;
                                camera_name.Dock = DockStyle.Fill;
                                camera_name.Text = camera.cameraName;
                                camera_name.Font = new Font(ApplicationConst.font_family_name, 10);
                                camera_name.ForeColor = Color.White;
                                camera_name.BackColor = Color.Transparent;
                                camera_name.TextAlign = ContentAlignment.MiddleLeft;
                                camera_name.MouseEnter += (s, e) => cameraMouseEnter(subTitlePanel, e);
                                camera_name.MouseLeave += (s, e) => cameraMouseLeave(subTitlePanel, e);
                                camera_name.MouseClick += (s, e) => cameraClick(subTitlePanel, e);
                                camera_name.MouseDoubleClick += (s, e) => cameraDoubleClick(subTitlePanel, e);
                                camera_name.MouseDown += (s, e) => cameraMouseDown(subTitlePanel, e);

                                subTitlePanel.Controls.Add(camera_name);
                                subTitlePanel.Controls.Add(camera_icon);
                                live_left_camera_flp.Controls.Add(subTitlePanel);
                                liveLeftCameraFlpHeight += (int)(30 * returnHeightSizeRatio());
                            }
                        }
                    }
                    tagTriangleIcon++;
                }
                if (liveLeftCameraFlpHeight > live_left_camera_flp.Height)
                {
                    live_left_camera_flp.Height = liveLeftCameraFlpHeight;
                }
            }
        }

        private void resize(object sender, EventArgs e)
        {
            top_content.Controls.Clear();
            live_left_camera_flp.Controls.Clear();
            InitializeAfter();
            InitializeCameraGroup();
        }

        private void load(object sender, EventArgs e)
        {
            original_width = this.ClientSize.Width;
            original_height = this.ClientSize.Height;
        }
        private void cameraGroupBorderPaint(object? sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            Graphics g = e.Graphics;

            using (Pen pen = new Pen(Color.FromArgb(47, 47, 47), ApplicationConst.border_thickness))
            {
                //g.DrawLine(pen, 0, 0, panel.Width, 0);

                g.DrawLine(pen, 0, panel.Height - 1, panel.Width - 10, panel.Height - 1);
            }
        }

        private void cameraBorderPaint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            Graphics g = e.Graphics;

            using (Pen pen = new Pen(Color.FromArgb(47, 47, 47), ApplicationConst.border_thickness))
            {
                //g.DrawLine(pen, 0, 0, panel.Width, 0);

                g.DrawLine(pen, 0, panel.Height - 1, panel.Width, panel.Height - 1);
            }
        }
        private void triangleIconClick(object? sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
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
                live_left_camera_flp.Controls.Clear();
                InitializeCameraGroup();
            }
        }

        private void cameraDoubleClick(object? sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel;
            sendLinkDoubleClick?.Invoke(panel.Tag.ToString());
        }

        private void cameraClick(object? sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel;
            if(e.Button == MouseButtons.Left)
            {
                //if (!chosenCameras.Contains(panel))
                //{
                //    if (isCtrlKeyPress && !isShiftKeyPress)
                //    {
                //        chosenCameras.Add(panel);
                //        panel.BackColor = Color.FromArgb(114, 82, 82);
                //    }
                //    else if (isShiftKeyPress && !isCtrlKeyPress)
                //    {
                //        Panel beginIndexPanel = new Panel();
                //        if (chosenCameras.Count == 0)
                //        {
                //            chosenCameras.Add(panel);
                //        }
                //        else
                //        {
                //            beginIndexPanel = chosenCameras.Last();
                //            int beginIndex = cameraPanelList.IndexOf(beginIndexPanel);
                //            int endIndex = cameraPanelList.IndexOf(panel);
                //            List<Panel> listSelected = new List<Panel>();
                //            if (beginIndex > endIndex)
                //            {
                //                listSelected = cameraPanelList.GetRange(endIndex, beginIndex - endIndex + 1);
                //            }
                //            else
                //            {
                //                listSelected = cameraPanelList.GetRange(beginIndex, endIndex - beginIndex + 1);
                //            }
                //            foreach (var camera in chosenCameras)
                //            {
                //                camera.BackColor = Color.FromArgb(64, 64, 64);
                //            }
                //            chosenCameras.Clear();
                //            chosenCameras.AddRange(listSelected);
                //            foreach (var item in chosenCameras)
                //            {
                //                item.BackColor = Color.FromArgb(114, 82, 82);
                //            }
                //        }
                //    }
                //    else
                //    {
                //        foreach (var camera in chosenCameras)
                //        {
                //            camera.BackColor = Color.FromArgb(64, 64, 64);
                //        }
                //        chosenCameras.Clear();
                //        chosenCameras.Add(panel);
                //        panel.BackColor = Color.FromArgb(114, 82, 82);
                //    }

                //}
            }
        }

        private void cameraMouseEnter(object? sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.BackColor = Color.FromArgb(114, 82, 82);
        }

        private void cameraMouseLeave(object? sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (!chosenCameras.Contains(panel))
            {
                panel.BackColor = Color.FromArgb(64, 64, 64);
            }
        }

        private void cameraMouseDown(object? sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel;
            if (e.Button == MouseButtons.Left)
            {
                if(e.Clicks == 2)
                {
                    cameraDoubleClick(sender, e);
                }
                if (!chosenCameras.Contains(panel))
                {
                    if (isCtrlKeyPress && !isShiftKeyPress)
                    {
                        chosenCameras.Add(panel);
                        panel.BackColor = Color.FromArgb(114, 82, 82);
                    }
                    else if (isShiftKeyPress && !isCtrlKeyPress)
                    {
                        Panel beginIndexPanel = new Panel();
                        if (chosenCameras.Count == 0)
                        {
                            chosenCameras.Add(panel);
                        }
                        else
                        {
                            beginIndexPanel = chosenCameras.Last();
                            int beginIndex = cameraPanelList.IndexOf(beginIndexPanel);
                            int endIndex = cameraPanelList.IndexOf(panel);
                            List<Panel> listSelected = new List<Panel>();
                            if (beginIndex > endIndex)
                            {
                                listSelected = cameraPanelList.GetRange(endIndex, beginIndex - endIndex + 1);
                            }
                            else
                            {
                                listSelected = cameraPanelList.GetRange(beginIndex, endIndex - beginIndex + 1);
                            }
                            foreach (var camera in chosenCameras)
                            {
                                camera.BackColor = Color.FromArgb(64, 64, 64);
                            }
                            chosenCameras.Clear();
                            chosenCameras.AddRange(listSelected);
                            foreach (var item in chosenCameras)
                            {
                                item.BackColor = Color.FromArgb(114, 82, 82);
                            }
                        }
                    }
                    else
                    {
                        foreach (var camera in chosenCameras)
                        {
                            camera.BackColor = Color.FromArgb(64, 64, 64);
                        }
                        chosenCameras.Clear();
                        chosenCameras.Add(panel);
                        panel.BackColor = Color.FromArgb(114, 82, 82);
                    }

                }
                panel.DoDragDrop(getListLinkChosenCameras(chosenCameras), DragDropEffects.Move);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------//
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

        private void updateIsExpandList()
        {
            List<CameraGroup> cameraGroups = _cameraService.getListCameraGroup(null);
            if (cameraGroups != null && cameraGroups.Count > 0)
            {
                for (int i = 0; i < cameraGroups.Count; i++)
                {
                    isExpandList.Add(false);
                }
            }
        }

        private void searchFunction(object? sender, EventArgs e)
        {
            live_left_camera_flp.Controls.Clear();
            InitializeCameraGroup();
        }

        private List<String> getListLinkChosenCameras(List<Panel> chosenCameras)
        {
            List<string> result = new List<string>();
            foreach (var camera in chosenCameras)
            {
                if(!string.IsNullOrEmpty((string?)camera.Tag))
                {
                    result.Add(camera.Tag.ToString());
                } 
            }
            return result;
        }

        //private List<Panel> GetPanelsInRange(Control container, int start, int end)
        //{
        //    var panelsInRange = container.Controls
        //        .OfType<Panel>() 
        //        .Where(p => int.TryParse(p.Name.Replace("subTitlePanel", ""), out int panelNumber)
        //                    && panelNumber >= start
        //                    && panelNumber <= end)
        //        .ToList(); 
        //    return panelsInRange;
        //}

    }
}
