   M S B A M L   `   `   `  ����H  DQuanLySanBong, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:QuanLySanBong.ViewsQuanLySanBong.Views  5   	   '    !QuanLySanBong.Views.LichSuThueSan   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:QuanLySanBong.Views     5   	     � Title$  Lịch sử Hóa đơn��5   	   $	��450��6!   $
��1000��6.    � WindowStartupLocation$ CenterScreen=�6;   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   $��10q�6!   .+�5      �� $��Center=�6   $��0,0,10,0q�63   Ngày bắt đầu6S   (  "System.Windows.Controls.DatePicker  5      -   5        $��dpBatDau��5      $��Center=�6)   $��0,0,10,0q�6D   �� 5      $��Center=�6   $��	10,0,10,0q�63   Ngày kết thúc6U     5      -   5        $��	dpKetThuc��5      $��Center=�6*   $��0,0,10,0q�6E   �� 5      $��Center=�6   $��10,0,5,0q�63   Sân6J   �� 5      -   5         ��Name$ cbSan��5      $��Center=�6&   $	��100��6A   �� 5      -   5         ��Name$ 	btnBaoCao��5      $��	30,0,10,0q�6(   $��50��6S   $��24��6^   .��6j   	Báo cáo6s   �� 5      -   5        $ btnTatCa��5      $��50��6>   $��20,0,0,0q�6I   .��6[   
Tất cả6c   5      �� 5   
   -   5        $ btnXoaTatCa��5      $��0��6&   $��Xóa tất cả ��63   $��70��6I   $��24��6T   $��Right=�6`   $��	0,0,150,0q�6|   6�   � 5   
   $��1��6    5      �� 5      $��* �6    �� 5      $
��Auto �6    .+�5#      &   System.Windows.Controls.DataGrid  -   5        $��HistoryDataGrid��5#      $��0��6.      AutoGenerateColumns$ False��6;   $��10q�6W      
IsReadOnly$
 True��6c      Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$	 Mã��6)   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 50 6S   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 65   �� *	InvoiceID+6S     5&      $ 	Tên sân��6)   $		 100 6Z   
 6:   �� *StadiumName+6Z     5'      $ Ngày��6)   $	 80 6p   
 67   �� *InvoiceDate+ �� StringFormat$ 
dd/MM/yyyy��6p     5(      $ Giờ Bắt Đầu��6)   $	 80 6s   
 6>   �� *	StartTime+$ HH:mm:ss��6s     5)      $ Giờ Kết Thúc��6)   $	 80 6r   
 6?   �� *	EndTime+$ HH:mm:ss��6r     5*      $  Tổng thời gian (giờ)��6)   $	 90 6w   
 6G   �� *	TotalTime+$	 0.0��6w     5+      $ Tiền Sân��6)   $	 70 6k   
 6;   �� *
StadiumFee+$ N0��6k     5,      $ Dịch Vụ��6)   $	 70 6j   
 6:   �� *
ServiceFee+$ N0��6j     5-      $ Giảm giá��6)   $	 70 6i   
 6;   �� *
Discount+$ N0��6i     5.      $ Tổng Tiền��6)   $	 70 6l   
 6<   �� *
TotalPrice+$ N0��6l     5/      $ Ghi chú��6)   $		 170 6S   
 6:   �� *Note+6S   51      �� 54      $��1��6    �� Orientation$ 
Horizontal=�6&   $��10q�6?   ���#EEE.+�55      �� $��Tổng Tiền Sân: ��6   $
��Bold"�63   �� 56      -   5        $��TotalStadiumFeeText��56      $	��5,0q�67   �� 57      $��Tổng Dịch Vụ: ��6   $
��Bold"�62   $��20,0,0,0q�6D   �� 58      -	   5        $��TotalServiceFeeText��58      $	��5,0q�67   �� 59      $��Tổng Giảm Giá: ��6   $
��Bold"�63   $��20,0,0,0q�6E   �� 5:      -
   5        $��TotalDiscountText��5:      $	��5,0q�65   �� 5;      $��Tổng Cộng: ��6   $
��Bold"�6/   $��20,0,0,0q�6A   �� 5<      -   5        $��GrandTotalText��5<      $	��5,0q�62   5=      5>      �� 5A   
   -   5        $��Đóng��5A      $��Right=�6    $��Bottom=�6<   $��10q�6W   $��80��6c   $��2��6�   5B      5C      