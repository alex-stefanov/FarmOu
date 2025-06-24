using FarmOu.Data;
using FarmOu.Data.Models;
using FarmOu.Data.Repositories;
using FarmOu.Infrastructure.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FarmOu.Forms
{
    partial class Form4
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
            button1 = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            helpProvider1 = new HelpProvider();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(589, 26);
            label1.Name = "label1";
            label1.Size = new Size(298, 89);
            label1.TabIndex = 0;
            label1.Text = "My Tools";
            // 
            // button1
            // 
            button1.Location = new Point(1096, 902);
            button1.Name = "button1";
            button1.Size = new Size(291, 124);
            button1.TabIndex = 1;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(62, 166);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(1364, 693);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(155, 818);
            label2.Name = "label2";
            label2.Size = new Size(0, 41);
            label2.TabIndex = 3;
            label2.Visible = false;
            // 
            // button2
            // 
            button2.Location = new Point(759, 902);
            button2.Name = "button2";
            button2.Size = new Size(291, 124);
            button2.TabIndex = 4;
            button2.Text = "All Tools";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1462, 1118);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form4";
            Text = "Form4";
            Load += Form4_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private TextBox textBox1;
        public Label label2;
        private HelpProvider helpProvider1;
        private Button button2;
    }
}