   M S B A M L   `   `   `  ����H  DQuanLySanBong, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:QuanLySanBong.ViewsQuanLySanBong.Views  5   	   #    QuanLySanBong.Views.QuanLySan   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:QuanLySanBong.Views     5   	     � Title$  Quản Lý Sân��5   	   $	��400��6   $	��380��6*   ���#F5F5F5 � WindowStartupLocation$ CenterScreen=�6K   .��5	      � $��10q�6   .+�5   
   �� $��Quản Lý Sân Bóng��6   $��24(�6,   $
��Bold"�6:   $��Center=�6L   �� 5   
    �� Orientation$ 
Horizontal=�6   $��0,40,0,0q�6.   $	��Top=�6@   .+�5      �� $��
Tên Sân:��6   $��Center=�6(   $��5q�6C   �� 5      -   5         ��Name$ NameTextBox��5      $	��200��6+   $��5q�67   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ StadiumDataGrid��5         AutoGenerateColumns$ False��6,   $��	0,80,0,80q�6H      
IsReadOnly$
 True��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Tên Sân��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6O   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 66   �� *Name+6O   5      �� 5   
   $ 
Horizontal=�6   $��Center=�6.   $��Bottom=�6K   $��0,0,0,10q�6f   .+�5      �� -   5        $��Thêm��5      $	��100��6$   $��5q�60   6;   �� 5      -   5        $��Sửa��5      $	��100��6#   $��5q�6/   6:   �� 5      -   5        $
��Xóa��5      $	��100��6#   $��5q�6/   6:   5      5       5!      