   M S B A M L   `   `   `  ����  QuanLySanBong'    !QuanLySanBong.Views.QuanLyProduct   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Quản Lý Hàng hóa��5   	   $	��400��6"   $	��600��6/    � WindowStartupLocation$ CenterScreen=�6;   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $	��Top=�6.   $��0,0,0,10q�6F   .+�5      �� $��Tên sản phẩm:��6   $��Center=�6,   �� 5      -   5         ��Name$ txtProductName��5      $	��150��6.   $	��5,0q�6:   $��Center=�6G   $��Segoe UI)�6i   �� 5      $��
Giá bán:��6   $��Center=�6'   �� 5      -   5        $ txtSalePrice��5      $��25��6,   $	��5,0q�67   $��Center=�6D   �� 5      $��Center=�6   
.000 VND6=   5      � 5   
   $��0��6   $��	0,40,0,10q�6!   .+�5      �� -   5        $��Thêm��5      $��80��6$   $
��10,0q�6/   6=   �� 5      -   5        $��Cập nhật��5      $��80��6(   $
��10,0q�63   6A   �� 5      -   5        $
��Xóa��5      $��80��6#   $
��10,0q�6.   6<   5       &   System.Windows.Controls.DataGrid  5#   
   -   5          Name$ dataGridProducts��5#      $��1��6-      AutoGenerateColumns$ False��6:      
IsReadOnly$
 True��6V      Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 30 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	ProductID+6O     5'      $	 Tên sản phẩm��6%   $
 * 6T    6;   �� *Name+6T     5)      $	 	Giá bán��6%   $
 * 6T    66   �� *	SalePrice+6T   5,      5-      5.      