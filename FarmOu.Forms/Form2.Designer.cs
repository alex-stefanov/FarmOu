using FarmOu.Data;
using FarmOu.Data.Models;
using FarmOu.Data.Repositories;
using FarmOu.Infrastructure.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FarmOu.Forms
{
    partial class Form2
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

        #region Some Shit

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

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(706, 764);
            button1.Name = "button1";
            button1.Size = new Size(296, 109);
            button1.TabIndex = 0;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(603, 55);
            label1.Name = "label1";
            label1.Size = new Size(239, 89);
            label1.TabIndex = 1;
            label1.Text = "Sign in";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(205, 276);
            label2.Name = "label2";
            label2.Size = new Size(152, 41);
            label2.TabIndex = 2;
            label2.Text = "Username";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(429, 273);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(286, 47);
            textBox1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(205, 394);
            label3.Name = "label3";
            label3.Size = new Size(143, 41);
            label3.TabIndex = 4;
            label3.Text = "Password";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(428, 388);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(287, 47);
            textBox2.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(1092, 764);
            button2.Name = "button2";
            button2.Size = new Size(296, 109);
            button2.TabIndex = 6;
            button2.Text = "Register";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1476, 1113);
            Controls.Add(button2);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private Button button2;
    }
}