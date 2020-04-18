using System;
using System.Windows.Forms;

namespace NeuralNet
{
    partial class Form1
    {
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.epochTextbox = new System.Windows.Forms.TextBox();
            this.minibatchTextbox = new System.Windows.Forms.TextBox();
            this.learnrateTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.trainBtn = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.result = new System.Windows.Forms.PictureBox();
            this.hiddenLayerTextbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.result)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(657, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Epochs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(657, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "mini batch size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(657, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Learning Rate";
            // 
            // epochTextbox
            // 
            this.epochTextbox.Location = new System.Drawing.Point(660, 88);
            this.epochTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.epochTextbox.Name = "epochTextbox";
            this.epochTextbox.Size = new System.Drawing.Size(53, 22);
            this.epochTextbox.TabIndex = 3;
            this.epochTextbox.TextChanged += new System.EventHandler(this.epochTextbox_TextChanged);
            // 
            // minibatchTextbox
            // 
            this.minibatchTextbox.Location = new System.Drawing.Point(660, 132);
            this.minibatchTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.minibatchTextbox.Name = "minibatchTextbox";
            this.minibatchTextbox.Size = new System.Drawing.Size(53, 22);
            this.minibatchTextbox.TabIndex = 4;
            this.minibatchTextbox.TextChanged += new System.EventHandler(this.minibatchTextbox_TextChanged);
            // 
            // learnrateTextbox
            // 
            this.learnrateTextbox.Location = new System.Drawing.Point(660, 178);
            this.learnrateTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.learnrateTextbox.Name = "learnrateTextbox";
            this.learnrateTextbox.Size = new System.Drawing.Size(53, 22);
            this.learnrateTextbox.TabIndex = 5;
            this.learnrateTextbox.TextChanged += new System.EventHandler(this.learnrateTextbox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(563, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Network";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(657, 37);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(692, 37);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 28);
            this.button2.TabIndex = 9;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(33, 481);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 42);
            this.button3.TabIndex = 11;
            this.button3.Text = "Predict";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(199, 494);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 17);
            this.label5.TabIndex = 12;
            // 
            // trainBtn
            // 
            this.trainBtn.Location = new System.Drawing.Point(660, 218);
            this.trainBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trainBtn.Name = "trainBtn";
            this.trainBtn.Size = new System.Drawing.Size(94, 33);
            this.trainBtn.TabIndex = 13;
            this.trainBtn.Text = "Train";
            this.trainBtn.UseVisualStyleBackColor = true;
            this.trainBtn.Click += new System.EventHandler(this.trainBtn_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(33, 10);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(67, 25);
            this.button5.TabIndex = 14;
            this.button5.Text = "Clear";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.clear);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox1.Location = new System.Drawing.Point(33, 70);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(280, 280);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_Mouse_Down);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_Mouse_Move);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_Mouse_Up);
            // 
            // result
            // 
            this.result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.result.Location = new System.Drawing.Point(566, 290);
            this.result.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(178, 160);
            this.result.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.result.TabIndex = 16;
            this.result.TabStop = false;
            // 
            // hiddenLayerTextbox
            // 
            this.hiddenLayerTextbox.Location = new System.Drawing.Point(554, 88);
            this.hiddenLayerTextbox.Name = "hiddenLayerTextbox";
            this.hiddenLayerTextbox.Size = new System.Drawing.Size(73, 22);
            this.hiddenLayerTextbox.TabIndex = 17;
            this.hiddenLayerTextbox.TextChanged += new System.EventHandler(this.hiddenLayerTextbox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(551, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Hidden Layers";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 538);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.hiddenLayerTextbox);
            this.Controls.Add(this.result);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.trainBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.learnrateTextbox);
            this.Controls.Add(this.minibatchTextbox);
            this.Controls.Add(this.epochTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Neural Network";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox epochTextbox;
        private System.Windows.Forms.TextBox minibatchTextbox;
        private System.Windows.Forms.TextBox learnrateTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button trainBtn;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private PictureBox result;
        private TextBox hiddenLayerTextbox;
        private Label label6;
    }
}

