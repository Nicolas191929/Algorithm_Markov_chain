using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MarkovForm
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox tBInput;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox lBRoot;
		private System.Windows.Forms.ListBox lBChild;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox tBOut;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tBInput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lBRoot = new System.Windows.Forms.ListBox();
            this.lBChild = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tBOut = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tBInput
            // 
            this.tBInput.Location = new System.Drawing.Point(0, 0);
            this.tBInput.Multiline = true;
            this.tBInput.Name = "tBInput";
            this.tBInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tBInput.Size = new System.Drawing.Size(480, 288);
            this.tBInput.TabIndex = 0;
            this.tBInput.Text = resources.GetString("tBInput.Text");
            this.tBInput.TextChanged += new System.EventHandler(this.tBInput_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(144, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load into Chain";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lBRoot
            // 
            this.lBRoot.Location = new System.Drawing.Point(488, 0);
            this.lBRoot.Name = "lBRoot";
            this.lBRoot.Size = new System.Drawing.Size(96, 329);
            this.lBRoot.Sorted = true;
            this.lBRoot.TabIndex = 2;
            this.lBRoot.SelectedIndexChanged += new System.EventHandler(this.lBRoot_SelectedIndexChanged);
            // 
            // lBChild
            // 
            this.lBChild.Location = new System.Drawing.Point(584, 0);
            this.lBChild.Name = "lBChild";
            this.lBChild.Size = new System.Drawing.Size(96, 329);
            this.lBChild.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(224, 296);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 32);
            this.button2.TabIndex = 4;
            this.button2.Text = "Load from Chain";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(304, 296);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 32);
            this.button3.TabIndex = 5;
            this.button3.Text = "Output from Chain";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tBOut
            // 
            this.tBOut.Location = new System.Drawing.Point(0, 336);
            this.tBOut.Name = "tBOut";
            this.tBOut.Size = new System.Drawing.Size(680, 20);
            this.tBOut.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(688, 357);
            this.Controls.Add(this.tBInput);
            this.Controls.Add(this.tBOut);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lBChild);
            this.Controls.Add(this.lBRoot);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Markov Chain Test";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
		Markov.MarkovChain mc= new Markov.MarkovChain();
		private void button1_Click(object sender, System.EventArgs e)
		{
			mc.Load(tBInput.Text);
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			lBRoot.Items.Clear();
			Markov.Structs.RootWord w = new Markov.Structs.RootWord();
			foreach(object x in mc.Words)
			{
				w=(Markov.Structs.RootWord)mc.Words[((System.Collections.DictionaryEntry)x).Key];
				lBRoot.Items.Add(w.Word);
			}

		}

		private void lBRoot_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string index=(string)lBRoot.Items[lBRoot.SelectedIndex];
			index=index.ToLower();
			Markov.Structs.RootWord w = new Markov.Structs.RootWord();
			Markov.Structs.Child	 c = new Markov.Structs.Child();
			w=(Markov.Structs.RootWord)mc.Words[index];
			lBChild.Items.Clear();
			foreach(object x in w.Childs)
			{
				c=(Markov.Structs.Child)w.Childs[((System.Collections.DictionaryEntry)x).Key];
				lBChild.Items.Add(c.Word+"-"+( 
												 ( (double)c.Occurrence/(double)w.ChildCount )
												 *
												 100
											  )+"%"
								 );
			}
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			tBOut.Text=mc.Output();
		}

        private void tBInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
