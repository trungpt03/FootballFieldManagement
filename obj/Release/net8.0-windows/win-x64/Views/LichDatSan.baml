   M S B A M L   `   `   `  ���� H  DQuanLySanBong, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:QuanLySanBongQuanLySanBong      QuanLySanBong.LichDatSan   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:QuanLySanBong       � Title$  
LichDatSan��$	��800��$
��1500�� � WindowStartupLocation$ CenterScreen=����	#FFBBBBBB.��� $��20q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+�� $��0��$
��Left=�.+��� -    ��Name$ btnTruoc��$��20��$��40��$��Trước��$��Center=�$��0,0,10,0q�(  "System.Windows.Controls.DatePicker  -   $��dp��$	��120��$
��Left=�   FirstDayOfWeek$ Monday=�$��30�����#FFFFFF���#CCCCCC$��1q�$��16(�$��Center=�   SelectedDateFormat$ Short=�$��Center=��� -   $ btnSau��$��20��$��40��$	��Sau��$��Center=�$��10,0,0,0q��� -   $ 	btnHomNay��$��20��$��60��$��Hôm nay��$��Center=�$��10,0,0,0q��� -   $��DateTextBlock��$��16(�$��Center=�$��	10,0,0,10q�$��Center=��� ���	#FFE8E8E8���#E0E0E0$��1q� �� Padding$ 5q� �� CornerRadius$ 10��$��1��._��� $��0q�.+���  �� Orientation$ 
Horizontal=�$��10q�.+��� $��0,0,20,0q�$��Center=�.+��� $��Tên:��$
��Bold"�$��14(�$��0,0,0,5q�$��Segoe UI)��� -   	 ��Name$	 NameTextBox��$	��200��$��35��$��14(�$��Segoe UI)����#CCCCCC$��1q����#F9F9F9$��Center=��� $��0,0,20,0q�$��Center=�.+��� $��Số điện thoại:��$
��Bold"�$��14(�$��0,0,0,5q�$��Segoe UI)��� -   $	 PhoneTextBox��$��Center=�$	��200��$��35��$��14(�$��Segoe UI)����#CCCCCC$��1q����#F9F9F9�� $��0,0,20,0q�$��Center=�.+��� $��Sân:��$
��Bold"�$��14(�$��0,0,0,5q�$��Segoe UI)��� -   
 ��Name$
 FieldComboBox��$��Center=�$	��200��$��35�� �� SelectedIndex$ 0��$��14(�$��Segoe UI)����#CCCCCC$��1q����#F9F9F9���� *Fields+�� $��0,0,20,0q�$��Center=�.+��� $��Giờ vào:��$
��Bold"�$��14(�$��0,0,0,5q�$��Segoe UI)��� -	   $
 StartTimeComboBox��$��Center=�$	��150��$��35��$ 0��$��14(�$��Segoe UI)����#CCCCCC$��1q����#F9F9F9���� *	TimeSlots+�� $��0,0,20,0q�$��Center=�.+��� $��	Giờ ra:��$
��Bold"�$��14(�$��0,0,0,5q�$��Segoe UI)��� -
   $
 EndTimeComboBox��$��Center=�$	��150��$��35��$ 1��$��14(�$��Segoe UI)����#CCCCCC$��1q����#F9F9F9���� *	TimeSlots+�� -   $��Đặt Sân��$	��120��$��35��$��Center=�$��Bottom=�$��14(�$��Segoe UI)����	#FF1BE336� -    �Name$ TimeTableGrid��$��2�� � ColumnDefinitions �� $	��120 ��� $��* �.+��� $
��Auto=�$
��Auto=�$��2��.���� -    ��Name$ FieldRowsControl������ .R��� 