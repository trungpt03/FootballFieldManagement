   M S B A M L   `   `   `  ����   QuanLySanBong     QuanLySanBong.Views.DichVu   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Dịch vụ��$	��600��$	��800�� � WindowStartupLocation$ CenterScreen=�.��� $��10q� � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto � � ColumnDefinitions �� $
��1.5* ��� $
��1.3* �.+�� $��0��.+��� $��Gọi đồ ��$��Center=��� -    ��Name$ txtIDSan��$��Center=�$
��Bold"�$��15(�
���  ���� -    ��Name$ ProductListView��$��1��$��0��$��10q����� *
Products+ �� View �� .P��� $��Tên sản phẩm�� �� Width$	 100�� �� DisplayMemberBinding �� *Name+�� $��	Giá bán��$ 70��	 �� CellTemplate	 �� .R��� $��Center=����� *	SalePrice+
 �� StringFormat$
 {0:C}�� �� ConverterCulture$ vi-VN���� $��Số lượng��$	 130��	 �� .R���  �� Orientation$ 
Horizontal=�$��Center=�.+��� -   $��-��$��30���� $��40�� �� TextAlignment$ Center=�$��Center=����� *
Quantity+�� -   $��+��$��30���� $��Thành tiền��$ 70��	 �� .R��� $��Center=����� *
TotalPrice+$
 {0:C}��$ vi-VN���� -   $��OrderedProductsListView��$��10q�$��1��$��1������ *OrderedProducts+ �� .P��� $��Tên Sản Phẩm��$	 100�� �� *ProductName+�� $��Số Lượng��$ 70�� �� *
Quantity+�� $��Tổng Tiền��$ 70�� �� *
TotalPrice+$
 N0���� $��Hành Động��	 �� .R��� -   $
��Xóa��$��50������ �� $��2��$��2��$ 
Horizontal=�$��Center=�$��0,10,0,0q�.+��� -   $��
Đồng ý��$	��120��$��40��$��10q����#4CAF50
�������$
��Bold"��� -   $��Hủy��$	��120��$��40��$��10q����#F44336
�������$
��Bold"�