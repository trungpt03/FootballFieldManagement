   M S B A M L   `   `   `  ����   QuanLySanBong'    !QuanLySanBong.Views.QuanLyProduct   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Quản Lý Hàng hóa��$	��400��$	��600�� � WindowStartupLocation$ CenterScreen=�.��� $��10q� � RowDefinitions �� $
��Auto ��� $��* �.+���  �� Orientation$ 
Horizontal=�$	��Top=�$��0,0,0,10q�.+��� $��Tên sản phẩm:��$��Center=��� -    ��Name$ txtProductName��$	��150��$	��5,0q�$��Center=�$��Segoe UI)��� $��
Giá bán:��$��Center=��� -   $ txtSalePrice��$��25��$	��5,0q�$��Center=��� $��Center=�
.000 VND� $��0��$��	0,40,0,10q�.+��� -   $��Thêm��$��80��$
��10,0q��� -   $��Cập nhật��$��80��$
��10,0q��� -   $
��Xóa��$��80��$
��10,0q�&   System.Windows.Controls.DataGrid  -     Name$ dataGridProducts��$��1��   AutoGenerateColumns$ False��   
IsReadOnly$
 True��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 30 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	ProductID+  $	 Tên sản phẩm��$
 *  �� *Name+  $	 	Giá bán��$
 *  �� *	SalePrice+