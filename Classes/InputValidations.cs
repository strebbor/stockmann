using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Stockman.Classes
{
    public class InputValidations
    {
        #region validations
        public void Val_NotEmptyString(object sender, CancelEventArgs e, string errorMessage, ErrorProvider eProvider)
        {
            string checkText = getCheckText(sender);

            //validates and updates the error
            if (string.IsNullOrWhiteSpace(checkText))
            {
                createError(sender, e, errorMessage, eProvider);
            }
            else
            {
                cancelError(e);
            }
        }

        public void Val_MinMaxLength(object sender, CancelEventArgs e, string errorMessage, ErrorProvider eProvider, int minLength, int maxLength)
        {
            string checkText = getCheckText(sender);

            //validates and updates the error
            if (checkText.Length < minLength | checkText.Length > maxLength)
            {
                createError(sender, e, errorMessage, eProvider);
            }
            else
            {
                cancelError(e);
            }
        }

        public void Val_MinLength(object sender, CancelEventArgs e, string errorMessage, ErrorProvider eProvider, int minLength)
        {
            string checkText = getCheckText(sender);

            //validates and updates the error
            if (checkText.Length < minLength)
            {
                createError(sender, e, errorMessage, eProvider);
            }
            else
            {
                cancelError(e);
            }
        }

        public void Val_MaxLength(object sender, CancelEventArgs e, string errorMessage, ErrorProvider eProvider, int maxLength)
        {
            string checkText = getCheckText(sender);

            //validates and updates the error
            if (checkText.Length > maxLength)
            {
                createError(sender, e, errorMessage, eProvider);
            }
            else
            {
                cancelError(e);
            }
        }

        public void Val_IsNumeric(object sender, CancelEventArgs e, string errorMessage, ErrorProvider eProvider)
        {
            string checkText = getCheckText(sender);

            //validates and updates the error
            int result = 0;
            if (!int.TryParse(checkText, out result))
            {
                createError(sender, e, errorMessage, eProvider);
            }
            else
            {
                cancelError(e);
            }
        }
        #endregion

        #region privates
        private void cancelError(CancelEventArgs e)
        {
            e.Cancel = false;
        }
        private void createError(object sender, CancelEventArgs e, string errorMessage, ErrorProvider eProvider)
        {
            e.Cancel = true;
            eProvider.SetError((Control)sender, errorMessage);
        }
        private string getCheckText(object sender)
        {
            string checkText = string.Empty;

            switch (sender.GetType().Name.ToUpper())
            {
                case "TEXTBOX":
                    {
                        TextBox txt = (TextBox)sender;
                        checkText = txt.Text;

                    } break;
                case "LISTBOX":
                    {
                        ListBox lb = (ListBox)sender;
                        checkText = lb.Text;
                    }
                    break;
                case "COMBOBOX":
                    {
                        ComboBox cb = (ComboBox)sender;
                        checkText = cb.Text;
                    }break;
                default: throw new NotImplementedException();
            }

            return checkText;
        }
        private int getNumeric(object sender)
        {
            string text = getCheckText(sender);
            return int.Parse(text);
        }
        #endregion
    }
}
