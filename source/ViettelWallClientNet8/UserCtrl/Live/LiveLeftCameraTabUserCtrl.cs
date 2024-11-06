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
using ViettelWallClientNet8.Util.Const;

namespace ViettelWallClientNet8.UserCtrl.Live
{

    public partial class LiveLeftCameraTabUserCtrl : UserControl
    {
        private float original_width;
        private float original_height;
        public LiveLeftCameraTabUserCtrl()
        {
            InitializeComponent();
            InitializeAfter();
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



            SearchTextBox searchTextBox = new SearchTextBox();
            searchTextBox.Multiline = true;
            searchTextBox.Height = 30;
            searchTextBox.Dock = DockStyle.Top;
            searchTextBox.Font = new Font(ApplicationConst.font_family_name, 9);
            searchTextBox.ForeColor = Color.Gray;
            searchTextBox.Text = "Nhập tên camera...";
            searchTextBox.BackColor = Color.FromArgb(64, 64, 64);


            searchTextBox.GotFocus += (sender, e) =>
            {
                if (searchTextBox.Text == "Nhập tên camera...")
                {
                    searchTextBox.Text = "";
                    searchTextBox.ForeColor = Color.FromArgb(64, 64, 64);
                }
            };
            searchTextBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(searchTextBox.Text))
                {
                    searchTextBox.Text = "Nhập tên camera...";
                    searchTextBox.ForeColor = Color.FromArgb(64, 64, 64);
                }
            };

            top_content.Controls.Add(searchTextBox);
            top_content.Controls.Add(titleLabel);



            // Tạo TreeView và cấu hình ImageList cho TreeNode icons
            main_content_panel.AutoScroll = false;
            main_content_panel.HorizontalScroll.Maximum = 0;
            main_content_panel.VerticalScroll.Maximum = 0;
            main_content_panel.AutoScroll = true;
            live_left_camera_flp.Size = new Size(main_content_panel.Width, main_content_panel.Height);
            TreeView cameraTreeView = new TreeView();
            //cameraTreeView.Dock = DockStyle.Right;
            cameraTreeView.Size = new Size(live_left_camera_flp.Width, live_left_camera_flp.Height);
            cameraTreeView.BackColor = Color.FromArgb(64, 64, 64);
            cameraTreeView.ForeColor = Color.White;
            cameraTreeView.Font = new Font(ApplicationConst.font_family_name, 9);
            cameraTreeView.ShowLines = false; // Ẩn các đường kết nối giữa các node
            cameraTreeView.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            cameraTreeView.DrawNode += cameraTreeView_drawNode;
            cameraTreeView.ShowPlusMinus = false;

            // Tạo ImageList và thêm biểu tượng cho TreeNode
            ImageList imageList = new ImageList();
            imageList.Images.Add("camera", Properties.Resources.camera_icon); // Icon camera
            imageList.Images.Add("store", Properties.Resources.store_icon); // Icon store
            cameraTreeView.ImageList = imageList;

            // Tạo đối tượng TreeNode cho "380 Lạc Long Quân"
            TreeNode node1 = new TreeNode("380 Lạc Long Quân");
            node1.ImageKey = "store"; // Icon của store
            node1.SelectedImageKey = "store";

            // Thêm các node con cho node1
            TreeNode cameraNode1 = new TreeNode("AI_CAMERA_HPG_001");
            cameraNode1.ImageKey = "camera";
            cameraNode1.SelectedImageKey = "camera";
            node1.Nodes.Add(cameraNode1);

            TreeNode cameraNode2 = new TreeNode("AI_CAMERA_HPG_002");
            cameraNode2.ImageKey = "camera";
            cameraNode2.SelectedImageKey = "camera";
            node1.Nodes.Add(cameraNode2);

            TreeNode cameraNode3 = new TreeNode("AI_CAMERA_HPG_003");
            cameraNode3.ImageKey = "camera";
            cameraNode3.SelectedImageKey = "camera";
            node1.Nodes.Add(cameraNode3);

            TreeNode cameraNode4 = new TreeNode("AI_CAMERA_HPG_004");
            cameraNode4.ImageKey = "camera";
            cameraNode4.SelectedImageKey = "camera";
            node1.Nodes.Add(cameraNode4);

            // Tạo các node cho "Store Keangnam" và "Store Hoa Lac"
            TreeNode node2 = new TreeNode("Store Keangnam");
            node2.ImageKey = "store";
            node2.SelectedImageKey = "store";

            TreeNode node3 = new TreeNode("Store Hoa Lac");
            node3.ImageKey = "store";
            node3.SelectedImageKey = "store";

            cameraTreeView.Nodes.Add(node1);
            cameraTreeView.Nodes.Add(node2);
            cameraTreeView.Nodes.Add(node3);

            // Thêm các control vào panel
            live_left_camera_flp.Controls.Add(cameraTreeView);
        }

        private void cameraTreeView_drawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node.Nodes.Count > 0) // Kiểm tra nếu node có child
            {
                // Xác định vị trí vẽ tam giác
                Point trianglePoint = new Point(e.Bounds.Left - 10, e.Bounds.Top + e.Bounds.Height / 2);
                DrawTriangle(e.Graphics, trianglePoint, e.Node.IsExpanded);
            }

            // Vẽ văn bản của node
            e.DrawDefault = true;
        }

        private void DrawTriangle(Graphics g, Point point, bool isExpanded)
        {
            // Tạo hình tam giác
            Point[] triangle = new Point[]
            {
                new Point(point.X, point.Y - 5), // đỉnh trên
                new Point(point.X + 5, point.Y + 5), // đỉnh bên phải
                new Point(point.X - 5, point.Y + 5)  // đỉnh bên trái
            };

            // Vẽ tam giác
            g.FillPolygon(isExpanded ? Brushes.Gray : Brushes.Black, triangle);
        }

        private void resize(object sender, EventArgs e)
        {
            top_content.Controls.Clear();
            live_left_camera_flp.Controls.Clear();
            InitializeAfter();

        }

        private void load(object sender, EventArgs e)
        {
            original_width = this.ClientSize.Width;
            original_height = this.ClientSize.Height;
            //top_content.Controls.Clear();
            //InitializeAfter();
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
