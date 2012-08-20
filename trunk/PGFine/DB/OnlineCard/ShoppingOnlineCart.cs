using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for ShoppingOnlineCart
/// </summary>
public class ShoppingOnlineCart
{
    private int masach;
    private string Tensach;
    private int Soluong;
    private double dongia;
    private double Tonggia;
    public ShoppingOnlineCart(int _ma, string _ten, int _luong, double _gia, string size, string Imagespath, string Codeproduct, string Imagescolor)
	{
        this.masach = _ma;
        this.Tensach = _ten;
        this.Soluong = _luong;
        this.dongia = _gia;
        this.KichCo = size;
        this.ImagesPath = Imagespath;
        this.CodeProduct = Codeproduct;
        this.ImagesColor = Imagescolor;      
	}
    public int Ma
    {
        set { masach=value;}
        get { return masach;}
    }
    public string Ten
    {
        set { Tensach = value; }
        get { return Tensach; }
    }

    private string Kichco;
    public string KichCo
    {
        set { Kichco = value; }
        get { return Kichco; }
    }

    private string Imagespath;
    public string ImagesPath
    {
        set { Imagespath = value; }
        get { return Imagespath; }
    }

    private string Codeproduct;
    public string CodeProduct
    {
        set { Codeproduct = value; }
        get { return Codeproduct; }
    }
    private string Imagescolor;
    public string ImagesColor
    {
        set { Imagescolor = value; }
        get { return Imagescolor; }
    }

    public int Luong
    {
        set { Soluong = value; }
        get { return Soluong; }
    }
    public double Gia
    {
        set { dongia = value; }
        get { return dongia; }
    }
    public double Tong
    {
        set { Tonggia = value; }
        get { return (Gia * Soluong); }
    }
   
   }
public class Cart
{
    private Hashtable _table = new Hashtable();
    private double _tong = 0;

    public void Add(int id, string name, double gia, int Sluong, string Size, string Imagespath, string Codeproduct, string Imagescolor)
    {
        // Nếu sản phẩm không có trong giỏ hàng thì thêm hàng vào giỏ
        if (_table[id] == null)
        {
           // ShoppingOnlineCart hd = new ShoppingOnlineCart(id, name, 1, gia);  'vu Tshirt
            ShoppingOnlineCart hd = new ShoppingOnlineCart(id, name, Sluong, gia, Size, Imagespath, Codeproduct, Imagescolor);
            _table.Add(id, hd);
            _tong += hd.Tong;
        }

         //Nếu đã có sản phẩm trong giỏ thì cập nhật thêm sản phẩm
        else
        {
            ShoppingOnlineCart hd = (ShoppingOnlineCart)_table[id];
            hd.Luong += 1;
            hd.Tong += hd.Gia;
            _tong += hd.Gia;
            hd.KichCo = hd.KichCo + "," + Size;
            hd.ImagesColor = hd.ImagesColor + Imagescolor;
        }
    }
    public void Remove(int id)
    {
        if (_table[id] != null)
        {
            ShoppingOnlineCart row = (ShoppingOnlineCart)_table[id];
            _tong -= row.Tong;
            _table.Remove(id);
        }
    }
    public void Update(int id, int newQty)
    {
        if (_table[id] != null)
        {
            ShoppingOnlineCart row = (ShoppingOnlineCart)_table[id];
            _tong -= row.Tong;
            row.Luong = newQty;
            row.Tong = row.Luong * row.Gia;
            _tong += row.Tong;
        }
    }
    public ICollection Table
    {
        get { return _table.Values; }
    }
    public Hashtable _reHastable
    {
        get { return _table; }
    }
    public double TotalPrice
    {
        get { return _tong; }
    }

}
