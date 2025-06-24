using FarmOu.Data;
using FarmOu.Data.Models;
using FarmOu.Data.Repositories;
using FarmOu.Infrastructure.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FarmOu.Forms
{
    partial class Form3
    {

        #region Db Context

        private static FarmOuDbContext context = new FarmOuDbContext();

        #endregion

        #region User Manager

        private static UserStore<Farmer> userStore = new UserStore<Farmer>(context);
        private static OptionsWrapper<IdentityOptions> options = new OptionsWrapper<IdentityOptions>(new IdentityOptions());
        private static PasswordHasher<Farmer> passwordHasher = new PasswordHasher<Farmer>();
        private static UserValidator<Farmer> userValidator = new UserValidator<Farmer>();
        private static PasswordValidator<Farmer> passwordValidator = new PasswordValidator<Farmer>();
        private static UpperInvariantLookupNormalizer keyNormalizer = new UpperInvariantLookupNormalizer();
        private static IdentityErrorDescriber errors = new IdentityErrorDescriber();
        private static UserManager<Farmer> userManager = new UserManager<Farmer>(
            userStore,
            options,
            passwordHasher,
            [userValidator],
            [passwordValidator],
            keyNormalizer,
            errors,
            null!,
            null!
        );

        #endregion

        #region Ripositories

        private static Repository<Crop, string> cropRepository = new Repository<Crop, string>(context);
        private static Repository<CropBuying, object> cropBuyingRepository = new Repository<CropBuying, object>(context);
        private static Repository<CropSell, object> cropSellRepository = new Repository<CropSell, object>(context);
        private static Repository<Farmer, string> farmerRepository = new Repository<Farmer, string>(context);
        private static Repository<FarmerCrop, object> farmerCropRepository = new Repository<FarmerCrop, object>(context);
        private static Repository<FarmerTool, object> farmerToolRepository = new Repository<FarmerTool, object>(context);
        private static Repository<FarmingSession, object> farmingSessionRepository = new Repository<FarmingSession, object>(context);
        private static Repository<Tool, string> toolRepository = new Repository<Tool, string>(context);
        private static Repository<ToolBuying, object> toolBuyingRepository = new Repository<ToolBuying, object>(context);
        private static Repository<XpLevel, int> xpLevelRepository = new Repository<XpLevel, int>(context);

        #endregion

        #region Services

        private static UserService userService = new UserService(
            userManager,
            farmerToolRepository);
        private static CropBazarService cropBazarService = new CropBazarService(
            cropRepository,
            cropBuyingRepository,
            cropSellRepository,
            farmerRepository,
            farmerCropRepository);
        private static ToolBazarService toolBazarService = new ToolBazarService(
            toolRepository,
            farmerToolRepository,
            toolBuyingRepository,
            farmerRepository);
        private static FarmSessionService farmingSessionService = new FarmSessionService(
            farmerRepository,
            cropRepository,
            toolRepository,
            xpLevelRepository,
            farmingSessionRepository,
            farmerCropRepository);
        private static ToolService toolService = new ToolService(
            toolRepository,
            farmerToolRepository);
        private static CropService cropService = new CropService(
            cropRepository,
            farmerCropRepository);

        #endregion

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            linkLabel1 = new LinkLabel();
            label10 = new Label();
            linkLabel2 = new LinkLabel();
            label11 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(591, 41);
            label1.Name = "label1";
            label1.Size = new Size(226, 89);
            label1.TabIndex = 0;
            label1.Text = "Profile";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(128, 260);
            label2.Name = "label2";
            label2.Size = new Size(152, 41);
            label2.TabIndex = 1;
            label2.Text = "FirstName";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(128, 369);
            label3.Name = "label3";
            label3.Size = new Size(149, 41);
            label3.TabIndex = 2;
            label3.Text = "LastName";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(128, 463);
            label4.Name = "label4";
            label4.Size = new Size(88, 41);
            label4.TabIndex = 3;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(128, 559);
            label5.Name = "label5";
            label5.Size = new Size(152, 41);
            label5.TabIndex = 4;
            label5.Text = "Username";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(382, 260);
            label6.Name = "label6";
            label6.Size = new Size(0, 41);
            label6.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(382, 369);
            label7.Name = "label7";
            label7.Size = new Size(0, 41);
            label7.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(382, 463);
            label8.Name = "label8";
            label8.Size = new Size(0, 41);
            label8.TabIndex = 7;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(382, 559);
            label9.Name = "label9";
            label9.Size = new Size(0, 41);
            label9.TabIndex = 8;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.MediumTurquoise;
            linkLabel1.AutoSize = true;
            linkLabel1.Cursor = Cursors.Hand;
            linkLabel1.Font = new Font("Segoe UI", 20F);
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(996, 41);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(298, 89);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "My Tools";
            linkLabel1.VisitedLinkColor = Color.FromArgb(0, 192, 0);
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(280, 198);
            label10.Name = "label10";
            label10.Size = new Size(0, 41);
            label10.TabIndex = 10;
            // 
            // linkLabel2
            // 
            linkLabel2.ActiveLinkColor = Color.MediumTurquoise;
            linkLabel2.AutoSize = true;
            linkLabel2.Cursor = Cursors.Hand;
            linkLabel2.Font = new Font("Segoe UI", 20F);
            linkLabel2.LinkColor = Color.Black;
            linkLabel2.Location = new Point(128, 41);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(208, 89);
            linkLabel2.TabIndex = 11;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Crops";
            linkLabel2.VisitedLinkColor = Color.MediumSeaGreen;
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(128, 198);
            label11.Name = "label11";
            label11.Size = new Size(44, 41);
            label11.TabIndex = 12;
            label11.Text = "Id";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1453, 1165);
            Controls.Add(label11);
            Controls.Add(linkLabel2);
            Controls.Add(label10);
            Controls.Add(linkLabel1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        public Label label6;
        public Label label7;
        public Label label8;
        public Label label9;
        private LinkLabel linkLabel1;
        public Label label10;
        private LinkLabel linkLabel2;
        private Label label11;
    }
}