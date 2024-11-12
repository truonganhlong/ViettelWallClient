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
        //interface
        private readonly ICameraService _cameraService;
        public LiveLeftCameraTabUserCtrl()
        {
            _cameraService = new CameraService();
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


            SearchIconTextBox searchTextBox = new SearchIconTextBox();
            searchTextBox.Dock = DockStyle.Top;

            top_content.Controls.Add(searchTextBox);
            top_content.Controls.Add(titleLabel);



            main_content_panel.AutoScroll = false;
            main_content_panel.HorizontalScroll.Maximum = 0;
            main_content_panel.VerticalScroll.Maximum = 0;
            main_content_panel.AutoScroll = true;
            //doi size live_left_camera_flp

            live_left_camera_flp.Size = new Size(main_content_panel.Width - 2, main_content_panel.Height - 2);
            
            //TreeView cameraTreeView = new TreeView();
            ////cameraTreeView.Dock = DockStyle.Right;
            //cameraTreeView.Size = new Size(live_left_camera_flp.Width, live_left_camera_flp.Height);
            //cameraTreeView.BackColor = Color.FromArgb(64, 64, 64);
            //cameraTreeView.ForeColor = Color.White;
            //cameraTreeView.Font = new Font(ApplicationConst.font_family_name, 9);
            //cameraTreeView.ShowLines = false;
            ////cameraTreeView.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            ////cameraTreeView.DrawNode += cameraTreeView_drawNode;
            //cameraTreeView.ShowPlusMinus = false;

            //// Tạo ImageList và thêm biểu tượng cho TreeNode
            //ImageList imageList = new ImageList();
            //imageList.Images.Add("camera", Properties.Resources.camera_icon); // Icon camera
            //imageList.Images.Add("store", Properties.Resources.store_icon); // Icon store
            //cameraTreeView.ImageList = imageList;

            //// Tạo đối tượng TreeNode cho "380 Lạc Long Quân"
            //TreeNode node1 = new TreeNode("380 Lạc Long Quân");
            //node1.ImageKey = "store"; // Icon của store
            //node1.SelectedImageKey = "store";

            //// Thêm các node con cho node1
            //TreeNode cameraNode1 = new TreeNode("AI_CAMERA_HPG_001");
            //cameraNode1.ImageKey = "camera";
            //cameraNode1.SelectedImageKey = "camera";
            //node1.Nodes.Add(cameraNode1);

            //TreeNode cameraNode2 = new TreeNode("AI_CAMERA_HPG_002");
            //cameraNode2.ImageKey = "camera";
            //cameraNode2.SelectedImageKey = "camera";
            //node1.Nodes.Add(cameraNode2);

            //TreeNode cameraNode3 = new TreeNode("AI_CAMERA_HPG_003");
            //cameraNode3.ImageKey = "camera";
            //cameraNode3.SelectedImageKey = "camera";
            //node1.Nodes.Add(cameraNode3);

            //TreeNode cameraNode4 = new TreeNode("AI_CAMERA_HPG_004");
            //cameraNode4.ImageKey = "camera";
            //cameraNode4.SelectedImageKey = "camera";
            //node1.Nodes.Add(cameraNode4);

            //// Tạo các node cho "Store Keangnam" và "Store Hoa Lac"
            //TreeNode node2 = new TreeNode("Store Keangnam");
            //node2.ImageKey = "store";
            //node2.SelectedImageKey = "store";

            //TreeNode node3 = new TreeNode("Store Hoa Lac");
            //node3.ImageKey = "store";
            //node3.SelectedImageKey = "store";

            //cameraTreeView.Nodes.Add(node1);
            //cameraTreeView.Nodes.Add(node2);
            //cameraTreeView.Nodes.Add(node3);

            //// Thêm các control vào panel
            //live_left_camera_flp.Controls.Add(cameraTreeView);
        }

        //private void cameraTreeView_drawNode(object sender, DrawTreeNodeEventArgs e)
        //{
        //    if (e.Node.Nodes.Count > 0) // Kiểm tra nếu node có child
        //    {
        //        // Xác định vị trí vẽ tam giác
        //        Point trianglePoint = new Point(e.Bounds.Left - 10, e.Bounds.Top + e.Bounds.Height / 2);
        //        DrawTriangle(e.Graphics, trianglePoint, e.Node.IsExpanded);
        //    }

        //    // Vẽ văn bản của node
        //    e.DrawDefault = true;
        //    //TreeNode node = e.Node;

        //    //// Đảm bảo rằng NodeFont không phải là null
        //    //Font nodeFont = node.NodeFont ?? new Font(ApplicationConst.font_family_name, 10); // Sử dụng font mặc định nếu NodeFont là null

        //    //// Vẽ background của node
        //    //e.Graphics.FillRectangle(new SolidBrush(e.Node.BackColor), e.Bounds);

        //    //// Vẽ text của node
        //    //e.Graphics.DrawString(node.Text, nodeFont, new SolidBrush(e.Node.ForeColor), e.Bounds.X + 20, e.Bounds.Y);

        //    //// Vẽ icon mở rộng/thu gọn tùy chỉnh
        //    //if (node.IsExpanded)
        //    //{
        //    //    // Vẽ icon mở rộng (ví dụ: icon mở rộng)
        //    //    e.Graphics.DrawImage(Properties.Resources.camera_icon, e.Bounds.X - 20, e.Bounds.Y + (e.Bounds.Height / 2) - 8);
        //    //}
        //    //else
        //    //{
        //    //    // Vẽ icon thu gọn (ví dụ: icon thu gọn)
        //    //    e.Graphics.DrawImage(Properties.Resources.broom_icon, e.Bounds.X - 20, e.Bounds.Y + (e.Bounds.Height / 2) - 8);
        //    //}
        //}

        //private void DrawTriangle(Graphics g, Point point, bool isExpanded)
        //{
        //    // Tạo hình tam giác
        //    Point[] triangle = new Point[]
        //    {
        //        new Point(point.X, point.Y - 5), // đỉnh trên
        //        new Point(point.X + 5, point.Y + 5), // đỉnh bên phải
        //        new Point(point.X - 5, point.Y + 5)  // đỉnh bên trái
        //    };

        //    // Vẽ tam giác
        //    g.FillPolygon(isExpanded ? Brushes.Gray : Brushes.Black, triangle);
        //}
        private void InitializeCameraGroup()
        {
            List<CameraGroup> cameraGroups = _cameraService.getListCameraGroup();
            if (cameraGroups != null)
            {
                int liveLeftCameraFlpHeight = 0;
                foreach (CameraGroup cameraGroup in cameraGroups)
                {
                    Panel titlePanel = new Panel();
                    //titlePanel.Height = 30;
                    titlePanel.BackColor = Color.FromArgb(64, 64, 64);
                    titlePanel.Paint += cameraBorderPaint;
                    titlePanel.Padding = new Padding(0, 1, 0, 1);
                    titlePanel.AutoSize = false;
                    titlePanel.Size = new Size(live_left_camera_flp.Width, 30);
                    //titlePanel.Dock = DockStyle.Top;

                    PictureBox triangle_icon = new PictureBox();
                    triangle_icon.Size = new Size(16, 16);
                    triangle_icon.SizeMode = PictureBoxSizeMode.AutoSize;
                    triangle_icon.Image = Properties.Resources.down_triangle_icon;
                    triangle_icon.Dock = DockStyle.Left;
                    triangle_icon.Padding = new Padding(0, 0, 7, 0);

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
                    liveLeftCameraFlpHeight += 30;

                    if (cameraGroup.listCameras != null && cameraGroup.listCameras.Count > 0)
                    {
                        foreach (Camera camera in cameraGroup.listCameras)
                        {
                            Panel subTitlePanel = new Panel();
                            subTitlePanel.BackColor = Color.FromArgb(64, 64, 64);
                            subTitlePanel.Paint += cameraBorderPaint;
                            subTitlePanel.Padding = new Padding(0, 1, 0, 1);
                            subTitlePanel.AutoSize = false;
                            subTitlePanel.Size = new Size(live_left_camera_flp.Width - 42, 30);
                            subTitlePanel.Anchor = AnchorStyles.Right | AnchorStyles.Top;


                            PictureBox camera_icon = new PictureBox();
                            camera_icon.Size = new Size(16, 16);
                            camera_icon.SizeMode = PictureBoxSizeMode.AutoSize;
                            camera_icon.Image = Properties.Resources.camera_icon;
                            camera_icon.Dock = DockStyle.Left;

                            Label camera_name = new Label();
                            camera_name.AutoSize = false;
                            camera_name.Dock = DockStyle.Fill;
                            camera_name.Text = camera.cameraName;
                            camera_name.Font = new Font(ApplicationConst.font_family_name, 10);
                            camera_name.ForeColor = Color.White;
                            camera_name.BackColor = Color.FromArgb(64, 64, 64);

                            subTitlePanel.Controls.Add(camera_name);
                            subTitlePanel.Controls.Add(camera_icon);
                            live_left_camera_flp.Controls.Add(subTitlePanel);
                        }
                    }
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
            //top_content.Controls.Clear();
            //InitializeAfter();
        }

        private void cameraBorderPaint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            Graphics g = e.Graphics;

            using (Pen pen = new Pen(Color.FromArgb(47, 47, 47), ApplicationConst.border_thickness))
            {
                //g.DrawLine(pen, 0, 0, panel.Width, 0);

                g.DrawLine(pen, 0, panel.Height - 1, panel.Width - 25, panel.Height - 1);
            }
        }


        private float returnMinSizeRatio()
        {
            if (this.ClientSize.Width == 0 && this.ClientSize.Height == 0)
            {
                return 1;
            }
            float widthRatio = (float)this.ClientSize.Width / original_width;
            float heightRatio = (float)this.ClientSize.Height / original_height;
            return Math.Min(widthRatio, heightRatio);
        }

        private float returnWidthSizeRatio()
        {
            if (this.ClientSize.Width == 0 && this.ClientSize.Height == 0)
            {
                return 1;
            }
            return (float)this.ClientSize.Width / original_width;
        }

        private float returnHeightSizeRatio()
        {
            if (this.ClientSize.Width == 0 && this.ClientSize.Height == 0)
            {
                return 1;
            }
            return (float)this.ClientSize.Height / original_height;
        }
    }
}
