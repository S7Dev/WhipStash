using System;
 using System.IO;
 using System.Windows.Forms;
 using System.Drawing;
 
 public class menuLand : Form
 {
 
   private Label menuLbl1;
   private Label readerrLbl1;
   private Label rptLbl;
   private Label nameLbl;
   private Label caryrLbl;
   private Label costLbl;
   private TextBox txtName;
   private TextBox txtCaryr;
   private TextBox txtCost;
   private Button cmdEXIT;
   private Button cmdShowData;
   private Button cmdAddData;
   private Button cmdAddRec;
   private string [] name = new string[20];
   private int [] caryr = new int[20];
   private double [] cost  = new double[20];
   private int numOfCars = 0;	   
   
   private Boolean toggle = false;

   
   public static void Main()
   {
    menuLand c = new menuLand();
	
	c.readData();
	   
       Application.Run(c);
   }
 
   public menuLand() 
   {
       Text = "Main Menu";
		Width = 300;
		Height = 600;
		BackColor = Color.Blue;
		ForeColor = Color.White;
		
       menuLbl1 = new Label();
       Controls.Add(menuLbl1);
       menuLbl1.Text = "Car Inventory Database";
       menuLbl1.Top = 10;
       menuLbl1.Left = 75;
       menuLbl1.Width = 200;

       readerrLbl1 = new Label();
       Controls.Add(readerrLbl1);
       readerrLbl1.Text = "";
       readerrLbl1.Top = 50;
       readerrLbl1.Left = 75;
       readerrLbl1.Width = 200;
	   readerrLbl1.Visible = false;

	   // Car Inventory Report Display Box
	   rptLbl = new Label();
       rptLbl.Text = "";
       rptLbl.Top = 40;
       rptLbl.Left = 10;
       rptLbl.Width = 275;
       rptLbl.Height = 480;
       Controls.Add(rptLbl);

	   
	// Car Name Prompt Label
	nameLbl = new Label();
	nameLbl.Top = 50;
	nameLbl.Left = 40;
	nameLbl.Width = 102;
	nameLbl.Text = "Enter Car Name:";
	nameLbl.Visible = false;
	Controls.Add(nameLbl);

	// Car Name TextBox
	txtName = new TextBox();
	txtName.Top = 50;
	txtName.Left = 148;
	txtName.Text = "";
	txtName.Visible = false;
	Controls.Add(txtName);

	// Car Year Prompt Label
	caryrLbl = new Label();
	caryrLbl.Top = 90;
	caryrLbl.Left = 40;
	caryrLbl.Width = 102;
	caryrLbl.Text = "Enter Car Year:";
	caryrLbl.Visible = false;
	Controls.Add(caryrLbl);

	// Car Year TextBox
	txtCaryr = new TextBox();
	txtCaryr.Top = 90;
	txtCaryr.Left = 148;
	txtCaryr.Text = "";
	txtCaryr.Visible = false;
	Controls.Add(txtCaryr);

		// Car Cost Prompt Label
	costLbl = new Label();
	costLbl.Top = 130;
	costLbl.Left = 40;
	costLbl.Width = 102;
	costLbl.Text = "Enter Car Value:";
	costLbl.Visible = false;
	Controls.Add(costLbl);

	// Car Cost TextBox
	txtCost = new TextBox();
	txtCost.Top = 130;
	txtCost.Left = 148;
	txtCost.Text = "";
	txtCost.Visible = false;
	Controls.Add(txtCost);

       // Exit Button	
       cmdEXIT = new Button();
       cmdEXIT.Text = "EXIT";
       cmdEXIT.Top = 520;
       cmdEXIT.Left = 200;
       cmdEXIT.Click += new System.EventHandler (cmdEXIT_Click);
       Controls.Add(cmdEXIT);

	   // Show Data Button
	   cmdShowData = new Button();
       cmdShowData.Text = "Car Report";
       cmdShowData.Top =520;
       cmdShowData.Left = 25;
       cmdShowData.Click += new System.EventHandler (cmdShowData_Click);
       Controls.Add(cmdShowData);

	   // Add Data Button
	   cmdAddData = new Button();
       cmdAddData.Text = "Add Cars";
       cmdAddData.Top = 520;
       cmdAddData.Left = 110;
       cmdAddData.Click += new System.EventHandler (cmdAddData_Click);
       //cmdAddData.Visible = false;
       Controls.Add(cmdAddData);

	   // Add Record Button
	   cmdAddRec = new Button();
       cmdAddRec.Text = "Add Record";
       cmdAddRec.Top = 220;
       cmdAddRec.Left = 110;
       cmdAddRec.Click += new System.EventHandler (cmdAddRec_Click);
       cmdAddRec.Visible = false;
       Controls.Add(cmdAddRec);
	   
	}
 
   private void cmdEXIT_Click(object sender, 
   System.EventArgs e)
   {
    /// put code here for exit ;      
	quit();
	this.Close();
   }

   
   private void cmdShowData_Click(object sender, 
   System.EventArgs e)
   {
    /// put code here for exit ;      
   /// lblOut.Text = "Hello " + txtName.Text;
   showList(name, caryr, cost, numOfCars);
   }

   private void cmdAddData_Click(object sender, 
   System.EventArgs e)
   {
    /// put code here for click to add to database ;      
   /// lblOut.Text = "Hello " + txtName.Text;
      toggleControls();
   }
 
 
  public void readData()
  {
	string strNum, strYear, strCost;
	int i;

	try
	{
	   StreamReader inFile = File.OpenText("carData.txt");
	   strNum = inFile.ReadLine();
	   try
	   {
		numOfCars = Convert.ToInt32(strNum);
	   }
	   catch (FormatException)
	   {
		Console.Out.WriteLine("\n\nCOULD NOT READ DATA FILE!");
        numOfCars = 0;
	   }

	   for (i = 0; i < numOfCars ; i++)
	   {
		name[i] = inFile.ReadLine();

		strYear = inFile.ReadLine();
		try
		{
			   caryr[i] = Convert.ToInt32(strYear);
		}
		catch	(FormatException)
		{
    
				Console.Out.Write("\nInvalid Year Format for " + name[i]);
			   Console.Out.WriteLine(", using 1888");
			   caryr[i] = 1888;
		}

		strCost = inFile.ReadLine();
	/*	try
		{
			   cost[i]  = Convert.ToInt32(strCost);
		}
		catch	(FormatException)
		{
    
				Console.Out.Write("\nInvalid Car Value Format for " + name[i]);
			   Console.Out.WriteLine(", using 9999");
			   cost[i] = 9999;
		}
*/
		if (double.TryParse(strCost, out cost[i]))
		{
		
		}
		else
		{
				Console.Out.Write("\nInvalid Car Value Format for " + name[i]);
			   Console.Out.WriteLine(", using 9999");
			   cost[i] = 9999;

		}
		
		
		
	  }

	   inFile.Close();
	   return;
	}
	catch(FileNotFoundException)
	{
        numOfCars = 0;
    	return ;
	}
  }

	  public void showList(string [] _name, int [] _year, double [] _cost, int _num)
	  {
		int i;

		// string formattedTxt = String.Format( "\n {0}  {1:C12}  {2}", _year[i], _cost[i], _name[i]);
		rptLbl.Text = "**************************";
		rptLbl.Text += "\n   Current Car Data";
		rptLbl.Text += "\n   " + _num + " Cars" ;
		rptLbl.Text += "\n***************************";

		for (i = 0; i < _num; i++)
		{string formattedTxt = String.Format( "\n {0}  {1:C}  {2}", _year[i], _cost[i], _name[i]);
		   rptLbl.Text += formattedTxt;	
		}
		   //rptLbl.Text += "\n" + _year[i] + "   $" + _cost[i] + " " +_name[i];	
	  }



   private void cmdAddRec_Click(object sender, 
   System.EventArgs e)
   {

	  String strYear;
	  String strCost;

	//	Console.Out.WriteLine("\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
	//	Console.Out.WriteLine("Adding Car Data");

		// Console.Out.Write("\n\nWhat is the Car Year?  ");
		strYear = txtCaryr.Text;
		try
		{
		   caryr[numOfCars] = Convert.ToInt32(strYear);
		   if( caryr[numOfCars] < 1850 || caryr[numOfCars] > 2025)
		   {
			 MessageBox.Show("Car Year must be between 1850 and 2025.\n NOT A VALID YEAR... Car Year set to 2018");
		   caryr[numOfCars] = 2018;
		   }
		}
		catch(FormatException)
		{
		  MessageBox.Show("NOT A VALID YEAR... Car Year set to 2018");
		   caryr[numOfCars] = 2018;
		}

		strCost = txtCost.Text;
		/* try
		{
		   cost[numOfCars] = Convert.ToInt32(strCost);
		   if( cost[numOfCars] < 0 || cost[numOfCars] > 20000000)
		   {
			 MessageBox.Show("Car Value must be between 0 and 20 Million.\n NOT A VALID Value... Car Value set to 9999");
		   cost[numOfCars] = 9999;
		   }
		}
		catch(FormatException)
		{
		  MessageBox.Show("NOT A VALID CAR VALUE... Car Value set to 9999");
		   cost[numOfCars] = 9999;
		}
        */
		
		if (double.TryParse(strCost, out cost[numOfCars]))
		{
		   if( cost[numOfCars] < 0 || cost[numOfCars] > 20000000)
		   {
			 MessageBox.Show("Car Value must be between 0 and 20 Million.\n NOT A VALID Value... Car Value set to 9999");
		   cost[numOfCars] = 9999;
		   }
		
		}
		else
		{
		  MessageBox.Show("Invalid Car Value Format for " + name[numOfCars] + "... Car Value set to 9999");
			   cost[numOfCars] = 9999;

		}
		
		name[numOfCars] = txtName.Text;

		numOfCars++;
		
		txtName.Text = "";
		txtCaryr.Text = "";
		txtCost.Text = "";
		
		//return numOfCars;
		toggleControls();
		rptLbl.Text = "";
	  }
			  
	   private void toggleControls()
	   {
		
		rptLbl.Visible = toggle;
		cmdEXIT.Visible = toggle;
		cmdShowData.Visible = toggle;
		cmdAddData.Visible = toggle;
       
		
		if (toggle)
		   toggle = false;
	    else
		   toggle = true;
	   
	    txtName.Visible = toggle;
		nameLbl.Visible = toggle;
		txtCaryr.Visible = toggle;
		caryrLbl.Visible = toggle;
	    txtCost.Visible = toggle;
		costLbl.Visible = toggle;
		cmdAddRec.Visible = toggle;
	   }
	   
	   
      public void quit()
	  {
					int i;


			StreamWriter outFile = File.CreateText("carData.txt");
			outFile.WriteLine(numOfCars);
			
			for(i = 0; i < numOfCars; i++)
			{
				outFile.WriteLine(name[i]);
				outFile.WriteLine(caryr[i]);
				outFile.WriteLine(cost[i]);
			}

			outFile.Close();

			MessageBox.Show("Your data was saved! \n\n Goodbye!");	
  
	  }
			  
			  
 } 
   
   
   