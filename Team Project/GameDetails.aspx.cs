using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// using statements required for EF DB access
using Team_Project.Models;
using System.Web.ModelBinding;

namespace Team_Project
{
    public partial class GameDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.getGame();
            }
        }

        protected void getGame()
        {



        }
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Redirect back to Students page
            Response.Redirect("~/Default.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            using (gameConnection db = new gameConnection())
            {
                {
                    Models.Game newGame = new Models.Game();

                    newGame.teamA = teamATextBox.Text;
                    newGame.teamB = teamBTextBox.Text;
                    newGame.teamA = teamAScore.Text;
                    newGame.teamB = teamBScore.Text;


                    db.Game.Add();
                }

                // save our changes - run an update
                db.SaveChanges();

                // Redirect back to the updated students page
                Response.Redirect("~/Default.aspx");
            }
        }
    }
    
}