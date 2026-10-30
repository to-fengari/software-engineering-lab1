namespace lab2
{
	partial class Form1
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.lblFactorialTitle = new System.Windows.Forms.Label();
			this.lblInputPrompt = new System.Windows.Forms.Label();
			this.txtInput = new System.Windows.Forms.TextBox();
			this.btnCalculateFactorial = new System.Windows.Forms.Button();
			this.lblResult = new System.Windows.Forms.Label();
			this.lblSumTitle = new System.Windows.Forms.Label();
			this.lblArrayPrompt = new System.Windows.Forms.Label();
			this.txtArrayInput = new System.Windows.Forms.TextBox();
			this.btnCalculateSum = new System.Windows.Forms.Button();
			this.lblSumResult = new System.Windows.Forms.Label();
			this.lblFibTitle = new System.Windows.Forms.Label();
			this.lblFibPrompt = new System.Windows.Forms.Label();
			this.txtFibInput = new System.Windows.Forms.TextBox();
			this.btnCalculateFibonacci = new System.Windows.Forms.Button();
			this.lblFibResult = new System.Windows.Forms.Label();
			this.lblPowerTitle = new System.Windows.Forms.Label();
			this.lblPowerPrompt = new System.Windows.Forms.Label();
			this.txtBase = new System.Windows.Forms.TextBox();
			this.lblExponentPrompt = new System.Windows.Forms.Label();
			this.txtExponent = new System.Windows.Forms.TextBox();
			this.btnCalculatePower = new System.Windows.Forms.Button();
			this.lblPowerResult = new System.Windows.Forms.Label();
			this.SuspendLayout();
			//
			// lblFactorialTitle
			//
			this.lblFactorialTitle.AutoSize = true;
			this.lblFactorialTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.lblFactorialTitle.Location = new System.Drawing.Point(40, 30);
			this.lblFactorialTitle.Name = "lblFactorialTitle";
			this.lblFactorialTitle.TabIndex = 0;
			this.lblFactorialTitle.Text = "Task 1 - Recursive Factorial";
			//
			// lblInputPrompt
			//
			this.lblInputPrompt.AutoSize = true;
			this.lblInputPrompt.Location = new System.Drawing.Point(40, 72);
			this.lblInputPrompt.Name = "lblInputPrompt";
			this.lblInputPrompt.TabIndex = 1;
			this.lblInputPrompt.Text = "Enter a number (n):";
			//
			// txtInput
			//
			this.txtInput.Location = new System.Drawing.Point(180, 69);
			this.txtInput.Name = "txtInput";
			this.txtInput.Size = new System.Drawing.Size(120, 23);
			this.txtInput.TabIndex = 2;
			//
			// btnCalculateFactorial
			//
			this.btnCalculateFactorial.Location = new System.Drawing.Point(320, 68);
			this.btnCalculateFactorial.Name = "btnCalculateFactorial";
			this.btnCalculateFactorial.Size = new System.Drawing.Size(160, 26);
			this.btnCalculateFactorial.TabIndex = 3;
			this.btnCalculateFactorial.Text = "Calculate Factorial";
			this.btnCalculateFactorial.UseVisualStyleBackColor = true;
			this.btnCalculateFactorial.Click += new System.EventHandler(this.btnCalculateFactorial_Click);
			//
			// lblResult
			//
			this.lblResult.AutoSize = true;
			this.lblResult.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.lblResult.Location = new System.Drawing.Point(40, 112);
			this.lblResult.Name = "lblResult";
			this.lblResult.TabIndex = 4;
			this.lblResult.Text = "Factorial:";
			//
			// lblSumTitle
			//
			this.lblSumTitle.AutoSize = true;
			this.lblSumTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.lblSumTitle.Location = new System.Drawing.Point(40, 165);
			this.lblSumTitle.Name = "lblSumTitle";
			this.lblSumTitle.TabIndex = 5;
			this.lblSumTitle.Text = "Task 2 - Sum of Array Elements";
			//
			// lblArrayPrompt
			//
			this.lblArrayPrompt.AutoSize = true;
			this.lblArrayPrompt.Location = new System.Drawing.Point(40, 207);
			this.lblArrayPrompt.Name = "lblArrayPrompt";
			this.lblArrayPrompt.TabIndex = 6;
			this.lblArrayPrompt.Text = "Numbers (comma separated):";
			//
			// txtArrayInput
			//
			this.txtArrayInput.Location = new System.Drawing.Point(250, 204);
			this.txtArrayInput.Name = "txtArrayInput";
			this.txtArrayInput.Size = new System.Drawing.Size(180, 23);
			this.txtArrayInput.TabIndex = 7;
			//
			// btnCalculateSum
			//
			this.btnCalculateSum.Location = new System.Drawing.Point(450, 203);
			this.btnCalculateSum.Name = "btnCalculateSum";
			this.btnCalculateSum.Size = new System.Drawing.Size(140, 26);
			this.btnCalculateSum.TabIndex = 8;
			this.btnCalculateSum.Text = "Calculate Sum";
			this.btnCalculateSum.UseVisualStyleBackColor = true;
			this.btnCalculateSum.Click += new System.EventHandler(this.btnCalculateSum_Click);
			//
			// lblSumResult
			//
			this.lblSumResult.AutoSize = true;
			this.lblSumResult.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.lblSumResult.Location = new System.Drawing.Point(40, 247);
			this.lblSumResult.Name = "lblSumResult";
			this.lblSumResult.TabIndex = 9;
			this.lblSumResult.Text = "Sum:";
			//
			// lblFibTitle
			//
			this.lblFibTitle.AutoSize = true;
			this.lblFibTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.lblFibTitle.Location = new System.Drawing.Point(40, 300);
			this.lblFibTitle.Name = "lblFibTitle";
			this.lblFibTitle.TabIndex = 10;
			this.lblFibTitle.Text = "Task 3 - Recursive Fibonacci";
			//
			// lblFibPrompt
			//
			this.lblFibPrompt.AutoSize = true;
			this.lblFibPrompt.Location = new System.Drawing.Point(40, 338);
			this.lblFibPrompt.Name = "lblFibPrompt";
			this.lblFibPrompt.TabIndex = 11;
			this.lblFibPrompt.Text = "Position (n):";
			//
			// txtFibInput
			//
			this.txtFibInput.Location = new System.Drawing.Point(130, 335);
			this.txtFibInput.Name = "txtFibInput";
			this.txtFibInput.Size = new System.Drawing.Size(80, 23);
			this.txtFibInput.TabIndex = 12;
			//
			// btnCalculateFibonacci
			//
			this.btnCalculateFibonacci.Location = new System.Drawing.Point(225, 334);
			this.btnCalculateFibonacci.Name = "btnCalculateFibonacci";
			this.btnCalculateFibonacci.Size = new System.Drawing.Size(150, 26);
			this.btnCalculateFibonacci.TabIndex = 13;
			this.btnCalculateFibonacci.Text = "Calculate Fibonacci";
			this.btnCalculateFibonacci.UseVisualStyleBackColor = true;
			this.btnCalculateFibonacci.Click += new System.EventHandler(this.btnCalculateFibonacci_Click);
			//
			// lblFibResult
			//
			this.lblFibResult.AutoSize = true;
			this.lblFibResult.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.lblFibResult.Location = new System.Drawing.Point(400, 338);
			this.lblFibResult.Name = "lblFibResult";
			this.lblFibResult.TabIndex = 14;
			this.lblFibResult.Text = "Fibonacci:";
			//
			// lblPowerTitle
			//
			this.lblPowerTitle.AutoSize = true;
			this.lblPowerTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.lblPowerTitle.Location = new System.Drawing.Point(40, 378);
			this.lblPowerTitle.Name = "lblPowerTitle";
			this.lblPowerTitle.TabIndex = 15;
			this.lblPowerTitle.Text = "Task 3 - Recursive Power";
			//
			// lblPowerPrompt
			//
			this.lblPowerPrompt.AutoSize = true;
			this.lblPowerPrompt.Location = new System.Drawing.Point(40, 414);
			this.lblPowerPrompt.Name = "lblPowerPrompt";
			this.lblPowerPrompt.TabIndex = 16;
			this.lblPowerPrompt.Text = "Base (x):";
			//
			// txtBase
			//
			this.txtBase.Location = new System.Drawing.Point(105, 411);
			this.txtBase.Name = "txtBase";
			this.txtBase.Size = new System.Drawing.Size(60, 23);
			this.txtBase.TabIndex = 17;
			//
			// lblExponentPrompt
			//
			this.lblExponentPrompt.AutoSize = true;
			this.lblExponentPrompt.Location = new System.Drawing.Point(180, 414);
			this.lblExponentPrompt.Name = "lblExponentPrompt";
			this.lblExponentPrompt.TabIndex = 18;
			this.lblExponentPrompt.Text = "Exponent (n):";
			//
			// txtExponent
			//
			this.txtExponent.Location = new System.Drawing.Point(270, 411);
			this.txtExponent.Name = "txtExponent";
			this.txtExponent.Size = new System.Drawing.Size(60, 23);
			this.txtExponent.TabIndex = 19;
			//
			// btnCalculatePower
			//
			this.btnCalculatePower.Location = new System.Drawing.Point(345, 410);
			this.btnCalculatePower.Name = "btnCalculatePower";
			this.btnCalculatePower.Size = new System.Drawing.Size(140, 26);
			this.btnCalculatePower.TabIndex = 20;
			this.btnCalculatePower.Text = "Calculate Power";
			this.btnCalculatePower.UseVisualStyleBackColor = true;
			this.btnCalculatePower.Click += new System.EventHandler(this.btnCalculatePower_Click);
			//
			// lblPowerResult
			//
			this.lblPowerResult.AutoSize = true;
			this.lblPowerResult.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.lblPowerResult.Location = new System.Drawing.Point(505, 414);
			this.lblPowerResult.Name = "lblPowerResult";
			this.lblPowerResult.TabIndex = 21;
			this.lblPowerResult.Text = "Result:";
			//
			// Form1
			//
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 470);
			this.Controls.Add(this.lblPowerResult);
			this.Controls.Add(this.btnCalculatePower);
			this.Controls.Add(this.txtExponent);
			this.Controls.Add(this.lblExponentPrompt);
			this.Controls.Add(this.txtBase);
			this.Controls.Add(this.lblPowerPrompt);
			this.Controls.Add(this.lblPowerTitle);
			this.Controls.Add(this.lblFibResult);
			this.Controls.Add(this.btnCalculateFibonacci);
			this.Controls.Add(this.txtFibInput);
			this.Controls.Add(this.lblFibPrompt);
			this.Controls.Add(this.lblFibTitle);
			this.Controls.Add(this.lblSumResult);
			this.Controls.Add(this.btnCalculateSum);
			this.Controls.Add(this.txtArrayInput);
			this.Controls.Add(this.lblArrayPrompt);
			this.Controls.Add(this.lblSumTitle);
			this.Controls.Add(this.lblResult);
			this.Controls.Add(this.btnCalculateFactorial);
			this.Controls.Add(this.txtInput);
			this.Controls.Add(this.lblInputPrompt);
			this.Controls.Add(this.lblFactorialTitle);
			this.Name = "Form1";
			this.Text = "Lab 2 - Data Structures and Recursion";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label lblFactorialTitle;
		private System.Windows.Forms.Label lblInputPrompt;
		private System.Windows.Forms.TextBox txtInput;
		private System.Windows.Forms.Button btnCalculateFactorial;
		private System.Windows.Forms.Label lblResult;
		private System.Windows.Forms.Label lblSumTitle;
		private System.Windows.Forms.Label lblArrayPrompt;
		private System.Windows.Forms.TextBox txtArrayInput;
		private System.Windows.Forms.Button btnCalculateSum;
		private System.Windows.Forms.Label lblSumResult;
		private System.Windows.Forms.Label lblFibTitle;
		private System.Windows.Forms.Label lblFibPrompt;
		private System.Windows.Forms.TextBox txtFibInput;
		private System.Windows.Forms.Button btnCalculateFibonacci;
		private System.Windows.Forms.Label lblFibResult;
		private System.Windows.Forms.Label lblPowerTitle;
		private System.Windows.Forms.Label lblPowerPrompt;
		private System.Windows.Forms.TextBox txtBase;
		private System.Windows.Forms.Label lblExponentPrompt;
		private System.Windows.Forms.TextBox txtExponent;
		private System.Windows.Forms.Button btnCalculatePower;
		private System.Windows.Forms.Label lblPowerResult;
	}
}
