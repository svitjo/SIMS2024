   M S B A M L   `   `   `  ����L  HReservationSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:ReservationSystem.View.ManagerView"ReservationSystem.View.ManagerView  5      ?    9ReservationSystem.View.ManagerView.HotelMainViewByManager   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:ReservationSystem.View.ManagerView     5        N� Title$  HotelMainViewByManager��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��HotelsDataGrid��5       $��1��6      AutoGenerateColumns$ False��66   $��
0,41,0,189q�6R    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5      "  6   .�5      ��  � ��
 ��ح�63   �� 5       � ��$
 Bold"�63   �� 5       � ��
 �   �63   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *Id+  5      $
 Name��6%   	 63   �� *Name+  5      $ Construction Year��6%   	 6@   �� *ConstructionYear+  5      $ Star Rating��6%   	 6:   �� *
StarRating+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Action��6)   
   CellTemplate
 5       �� 5!      .R�5"      �� -   5        $��Details��5"   %   
 � Tag 67   �� *Id+6J   5#      5%        5&      $	 Add��6)   
 5'      �� 5(      .R�5)      �� -   5        $	��New��5)   %    63   �� *Id+6F   5*      5,      5.        50   
   -   5        $��OtherStatusHotelsDataGrid��50       $��1��6   $ False��6A   $��	0,269,0,0q�6]   $��2��6p    51        52      $ ID��6%   	 61   �� *Id+  53      $
 Name��6%   	 63   �� *Name+  54      $ Construction Year��6%   	 6@   �� *ConstructionYear+  55      $ Star Rating��6%   	 6:   �� *
StarRating+  56      $ Action��6)   
 57      �� 58      .R�59      ��  �� Orientation$ 
Horizontal=�6)   .+�5:   "   �� -   5        $��Accept��5:   )   6:   �� 5;   "   -   5        $��Reject��5;   )   6:   5<      5=      5?      5A      5B      5C      