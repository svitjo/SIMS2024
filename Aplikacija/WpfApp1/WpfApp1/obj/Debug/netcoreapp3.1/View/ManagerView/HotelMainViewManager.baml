   M S B A M L   `   `   `  ����L  HReservationSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:ReservationSystem.View.ManagerView"ReservationSystem.View.ManagerView  5      =    7ReservationSystem.View.ManagerView.HotelMainViewManager   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:ReservationSystem.View.ManagerView     5        N� Title$  HotelMainViewManager��5	      .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6"   $
��Left=�69   $��	7,10,0,10q�6T   $
��1183��6g   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��Search Column��6   $��10q�62   .��5      �� $ 
Horizontal=�6!   .+�5      	� -   5        $��NameRadioButton��5   N   $
��Name��6&    	� 	GroupName$ SearchColumn��65    d� 	IsChecked$
 TrueY�6e   	� 5      -   5        $��IdRadioButton��5   L   $��Id��6&   $ SearchColumn��63   $	��5,0q�6a   	� 5      -   5        $��YearRadioButton��5   [   $��Construction Year��6&   $ SearchColumn��6B   $	��5,0q�6r   	� 5      -   5        $��RatingRadioButton��5   U   $��Star Rating��6&   $ SearchColumn��6<   $	��5,0q�6n   5      5      �� 5      $
��Sort��6   $	��182��6)   $
��10,0q�65   .��5      �� $ 
Horizontal=�6!   $
��Left=�6:   $	��241��6U   .+�5      �� -   5        $��By Year��5   !   $��5q�6X   
����ح�
�������$��75��6�   �� 5      -   5        $��	By Rating��5   !   $��5q�6T   
����ح�
�������$��75��6�   5      5      5       �� 5"      $ 
Horizontal=�6   .+�5#      �� $��Search hotels...��6   
����ح�$��24��6K   $��Center=�6W   �� 5$      -   5         ��Name$ 	SearchBox��5$      $	��200��6-   $��24��69   $	��5,0q�6E   �� 5%      -   5        $��Search��5%      $��24��6?   
����ح�
�������$	��5,0q�6u   �� 5&      -	   5        $��Search by Apartments��5&      $��24��6\   
����ح�
�������$	��5,0q�6�   5'      �� 5)      -
   5         ��Name$ ApartmentSearchPanel��5)      $y�	Collapsed=�67   $ 
Horizontal=�6N   $
��10,0q�6g   .+�5*      �� $��Search Apartments By��6   $��10q�69   .��5+      �� $ 
Horizontal=�6!   .+�5,      	� -   5        $��RoomsRadioButton��5,   X   $��Rooms��6&   $ ApartmentSearchColumn��66   $
 TrueY�6p   	� 5-      -   5        $��GuestsRadioButton��5-   Y   $��Guests��6&   $ ApartmentSearchColumn��67   $	��5,0q�6r   	� 5.      -   5        $��RoomsGuestsRadioButton��5.   a   $��Rooms + Guests��6&   $ ApartmentSearchColumn��6?   $	��5,0q�6   5/      50      �� 51      -   5        $ RoomsBox��51      $��50��6,   $��24��67   $	��5,0q�6C   �� 52      -   5        $ 	GuestsBox��52      $��50��6-   $��24��68   $	��5,0q�6D   �� 53      -   5        $��Search Apartments��53      $��24��6T   
����ح�
�������$	��5,0q�6�   54      55      &   System.Windows.Controls.DataGrid  57   
   -   5        $��HotelsDataGrid��57       $��1��6      AutoGenerateColumns$ False��66   $��0,41,0,0q�6R    � 	Resources 58      =  7System.Windows.Controls.Primitives.DataGridColumnHeader	 �� 
TargetType
 �� Property �� Value��%�   '        �� 59      "	  6   .�5:      �� 
 � ��
 ��ح�63   �� 5;      
 � ��$
 Bold"�63   �� 5<      
 � ��
 �   �63   5=      5>         Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5@      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5A      $
 Name��6%    63   �� *Name+  5B      $ Construction Year��6%    6@   �� *ConstructionYear+  5C      $ Star Rating��6%    6:   �� *
StarRating+5E      5F      5G      