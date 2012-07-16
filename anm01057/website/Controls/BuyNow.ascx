<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BuyNow.ascx.cs" Inherits="Controls_BuyNow" %>
<br />
<h1>
    Customer Information</h1>
<br />
Fullname:
<%= Profile.Fullname %>
<br />
Phone number:
<%= Profile.Phone %>
<br />
Address:
<%= Profile.Address.StreetName %>,
<%= Profile.Address.HouseNumber %>,
<%= Profile.Address.Ward %>,
<%= Profile.Address.District %>
