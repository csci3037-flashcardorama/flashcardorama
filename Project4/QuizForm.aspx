<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuizForm.aspx.cs" Inherits="Project4.QuizForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            FlashCard Quiz!<br />
            <br />
            Select which topic to be quized on!<br />
            <br />
            <asp:DropDownList ID="ddDecks" runat="server" Width="219px">
            </asp:DropDownList>
            <asp:Button ID="btnStart" runat="server" Text="Start" />
            <br />
            <br />
            Question: &quot;Back of Card goes here&quot;<br />
            <br />
            Answer:&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
            <br />
            <br />
            Results and % correct so far goes here</div>
    </form>
</body>
</html>
