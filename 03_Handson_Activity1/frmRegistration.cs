using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace _03_Handson_Activity1
{
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;

        public long StudentNumber(string studNum)
        {
            try
            {
                _StudentNo = long.Parse(studNum);
                
            }

            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            catch(ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            
                if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                try
                {
                    _ContactNo = long.Parse(Contact);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                }
                else
                {
                    Console.WriteLine("Enter Correct Contact Number Format!");
                }

            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                try
                {
                    _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            else
            {
                Console.WriteLine("Enter your name in String Format!");
            }

            return _FullName;
        }

        public int Age(string age)
        {
            if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                try
                {
                    _Age = Int32.Parse(age);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Enter Your Age in Number format!");
            }
            return _Age;
        }
        public frmRegistration()
        {
            InitializeComponent();
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListofPrograms = new string[]
            {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information System",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };
                for (int i = 0; i < 6; i++)
            {
                cbProgram.Items.Add(ListofPrograms[i].ToString());
            }

            string[] ListOfGender = new string[]
            {
                "Male",
                "Female"
            };

            for(int i = 0; i<2; i++)
            {
                cbGender.Items.Add(ListOfGender[i].ToString());
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            StudentInformationClass.SetFullName = FullName(txtLastName.Text,
                txtFirstName.Text, txtMiddleInitial.Text);
            StudentInformationClass.SetStudentNo = StudentNumber(txtStudNo.Text);
            StudentInformationClass.SetProgram = cbProgram.Text;
            StudentInformationClass.SetGender = cbGender.Text;
            StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);     
            StudentInformationClass.SetAge = Age(txtAge.Text);
            StudentInformationClass.SetBirthDay = datePickerBirthday.Value.ToString("yyyy-MM-dd");
            frmConfirmation frm = new frmConfirmation();

            try
            {
                if (_StudentNo == 0)
                {
                    txtStudNo.ResetText();
                }
                else if (_FullName == null)
                {
                    txtFirstName.ResetText();
                    txtLastName.ResetText();
                    txtMiddleInitial.ResetText();
                }
                else if (_Age == 0)
                {
                    txtAge.ResetText();
                }
                else if (_ContactNo == 0)
                {
                    txtContactNo.ResetText();
                }
                else
                {
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        txtAge.ResetText();
                        txtContactNo.ResetText();
                        txtFirstName.ResetText();
                        txtLastName.ResetText();
                        txtMiddleInitial.ResetText();
                        txtStudNo.ResetText();
                        datePickerBirthday.ResetText();
                        cbGender.ResetText();
                        cbProgram.ResetText();
                        _StudentNo = 0;
                        _FullName = null;
                        _Age = 0;
                        _ContactNo = 0;
                    }
                    else
                    {
                        frm.Dispose();
                    }
                }
            }

            catch (NullReferenceException Of)
            {
                MessageBox.Show(Of.Message);
            }

            
        }
    }
}
