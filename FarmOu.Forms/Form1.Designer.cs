using FarmOu.Data;
using FarmOu.Data.Models;
using FarmOu.Data.Repositories;
using FarmOu.Infrastructure.Implementations;
using FarmOu.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FarmOu.Forms
{
    partial class Form1
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

        #region Repositories

        private static IRepository<Crop, string> cropRepository = new Repository<Crop, string>(context);
        private static IRepository<CropBuying, object> cropBuyingRepository = new Repository<CropBuying, object>(context);
        private static IRepository<CropSell, object> cropSellRepository = new Repository<CropSell, object>(context);
        private static IRepository<Farmer, string> farmerRepository = new Repository<Farmer, string>(context);
        private static IRepository<FarmerCrop, object> farmerCropRepository = new Repository<FarmerCrop, object>(context);
        private static IRepository<FarmerTool, object> farmerToolRepository = new Repository<FarmerTool, object>(context);
        private static IRepository<FarmingSession, object> farmingSessionRepository = new Repository<FarmingSession, object>(context);
        private static IRepository<Tool, string> toolRepository = new Repository<Tool, string>(context);
        private static IRepository<ToolBuying, object> toolBuyingRepository = new Repository<ToolBuying, object>(context);
        private static IRepository<XpLevel, int> xpLevelRepository = new Repository<XpLevel, int>(context);

        #endregion

        #region Services

        private static IUserService userService = new UserService(
            userManager,
            farmerToolRepository);
        private static ICropBazarService cropBazarService = new CropBazarService(
            cropRepository,
            cropBuyingRepository,
            cropSellRepository,
            farmerRepository,
            farmerCropRepository);
        private static IToolBazarService toolBazarService = new ToolBazarService(
            toolRepository,
            farmerToolRepository,
            toolBuyingRepository,
            farmerRepository);
        private static IFarmSessionService farmingSessionService = new FarmSessionService(
            farmerRepository,
            cropRepository,
            toolRepository,
            xpLevelRepository,
            farmingSessionRepository,
            farmerCropRepository);
        private static IToolService toolService = new ToolService(
            toolRepository,
            farmerToolRepository);
        private static ICropService cropService = new CropService(
            cropRepository,
            farmerCropRepository);

        #endregion

        #region Some shit

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            textBox5 = new TextBox();
            label6 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(163, 260);
            label1.Name = "label1";
            label1.Size = new Size(160, 41);
            label1.TabIndex = 0;
            label1.Text = "First Name";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(355, 260);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(250, 47);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(163, 347);
            label2.Name = "label2";
            label2.Size = new Size(157, 41);
            label2.TabIndex = 2;
            label2.Text = "Last Name";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(355, 341);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(250, 47);
            textBox2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(163, 514);
            label3.Name = "label3";
            label3.Size = new Size(88, 41);
            label3.TabIndex = 4;
            label3.Text = "Email";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(355, 432);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(250, 47);
            textBox3.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(163, 432);
            label4.Name = "label4";
            label4.Size = new Size(152, 41);
            label4.TabIndex = 6;
            label4.Text = "Username";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(355, 514);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(250, 47);
            textBox4.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(163, 593);
            label5.Name = "label5";
            label5.Size = new Size(143, 41);
            label5.TabIndex = 8;
            label5.Text = "Password";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(355, 593);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(250, 47);
            textBox5.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 20.1F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(604, 90);
            label6.Name = "label6";
            label6.Size = new Size(270, 89);
            label6.TabIndex = 10;
            label6.Text = "Sign Up";
            // 
            // button1
            // 
            button1.Location = new Point(905, 910);
            button1.Name = "button1";
            button1.Size = new Size(188, 58);
            button1.TabIndex = 11;
            button1.Text = "Register";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1152, 910);
            button2.Name = "button2";
            button2.Size = new Size(188, 58);
            button2.TabIndex = 12;
            button2.Text = "Login";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1937, 1313);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(textBox5);
            Controls.Add(label5);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox5;
        private Label label6;
        private Button button1;
        private Button button2;
    }
}
