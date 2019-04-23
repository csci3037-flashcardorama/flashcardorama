using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project4
{
    public partial class QuizForm : System.Web.UI.Page
    {
        private dbEntities db = new dbEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            var decks = db.Decks.Select(s => new { Id = s.Id, DeckName = s.DeckName });

            if (decks.Any())
            {
                foreach (var deck in decks)
                {
                    ddDecks.Items.Add(new ListItem(deck.DeckName.ToString(), deck.Id.ToString()));

                }
            }
        }
    }
}