   M S B A M L   `   `   `  ���� H  DQuanLySanBong, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:QuanLySanBong.ViewsQuanLySanBong.Views  '    !QuanLySanBong.Views.LichSuThueSan   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:QuanLySanBong.Views       � Title$  Lịch sử Hóa đơn��$	��450��$
��1000�� � WindowStartupLocation$ CenterScreen=�.���  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+�� $��0��$��10q�.+��� $��Center=�$��0,0,5,0q�Ngày bắt đầu(  "System.Windows.Controls.DatePicker  -   $��dpBatDau��$��Center=�$��0,0,10,0q��� $��Center=�$��10,0,5,0q�Ngày kết thúc  -   $��	dpKetThuc��$��Center=�$��0,0,10,0q��� $��Center=�$��10,0,5,0q�Sân�� -    ��Name$ cbSan��$��Center=�$	��100���� -    ��Name$ 	btnBaoCao��$��	40,0,10,0q�$��50��$��24��.��	Báo cáo�� -   $ btnTatCa��$��50��$��20,0,0,0q�.��
Tất cả�� -   $ btnXoaTatCa��$��0��$��Xóa tất cả ��$��70��$��24��$��Right=�$��	0,0,150,0q�� $��1�� �� $��* ��� $
��Auto �.+�&   System.Windows.Controls.DataGrid  -   $��HistoryDataGrid��$��0��   AutoGenerateColumns$ False��$��10q�   
IsReadOnly$
 True��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$	 Mã��	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 50 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *	InvoiceID+  $ 	Tên sân��$		 100 
 �� *StadiumName+  $ Ngày��$	 80 
 �� *InvoiceDate+ �� StringFormat$ 
dd/MM/yyyy��  $ Giờ Bắt Đầu��$	 80 
 �� *	StartTime+$ HH:mm:ss��  $ Giờ Kết Thúc��$	 80 
 �� *	EndTime+$ HH:mm:ss��  $  Tổng thời gian (giờ)��$	 90 
 �� *	TotalTime+$	 0.0��  $ Tiền Sân��$	 70 
 �� *
StadiumFee+$ N0��  $ Dịch Vụ��$	 70 
 �� *
ServiceFee+$ N0��  $ Giảm giá��$	 70 
 �� *
Discount+$ N0��  $ Tổng Tiền��$	 70 
 �� *
TotalPrice+$ N0��  $ Ghi chú��$		 170 
 �� *Note+�� $��1�� �� Orientation$ 
Horizontal=�$��10q����#EEE.+��� $��Tổng Tiền Sân: ��$
��Bold"��� -   $��TotalStadiumFeeText��$	��5,0q��� $��Tổng Dịch Vụ: ��$
��Bold"�$��20,0,0,0q��� -	   $��TotalServiceFeeText��$	��5,0q��� $��Tổng Giảm Giá: ��$
��Bold"�$��20,0,0,0q��� -
   $��TotalDiscountText��$	��5,0q��� $��Tổng Cộng: ��$
��Bold"�$��20,0,0,0q��� -   $��GrandTotalText��$	��5,0q��� -   $��Đóng��$��Right=�$��Bottom=�$��10q�$��80��$��2��