   M S B A M L   `   `   `  ����  TransportModel    TransportModel.Import   5      \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5        N� Title$  Import��5      .��5      �  � ColumnDefinitions 5   
   �� 5      6!    � RowDefinitions 5	   
   �� 5
      $��45 �6   6*   �� 5      $��45 �6   6*   �� 5      $��45 �6   6*   �� 5      $��45 �6   6*   �� 5      6   �� 5      $��45 �6   6*   .+�5   
   �� $��0��6   $	��100��6   $
��Left=�6)   .��6D   Eastings Min:6T   �� 5   
   $��0��6   $	��100��6I   $
��Left=�6U   $��	100,2,0,2q�6p   ��6   �� *EastingsMin+ �� Mode$ TwoWay=�6�   �� 5   
   $��0��6   $	��100��6   $
��Left=�6)   $��	200,2,0,2q�6D   .��6W   Eastings Max:6f   �� 5   
   $��0��6   $	��100��6I   $
��Left=�6U   $��	300,2,0,2q�6p   ��6   �� *EastingsMax+$ TwoWay=�6�   �� 5   
   $��1��6   $	��100��6   $
��Left=�6)   .��6D   Northings Min:6T   �� 5   
   $��1��6   $	��100��6J   $
��Left=�6V   $��	100,2,0,2q�6q   ��6   �� *NorthingsMin+$ TwoWay=�6�   �� 5   
   $��1��6   $	��100��6   $
��Left=�6)   $��	200,2,0,2q�6D   .��6W   Northings Max:6g   �� 5   
   $��1��6   $	��100��6J   $
��Left=�6V   $��	300,2,0,2q�6q   ��6   �� *NorthingsMax+$ TwoWay=�6�   �� 5   
   -   5        $��	btnImport��5      $��2��6"   {�6G   �� *	CanImport+.��6g   Import6o   �� 5   
   -   5        $��btnCancelImport��5      $��3��6(   {�6S   �� *	CanImport+   BoolToOppositeBoolConverter �� 	Converter# [  .��6�   Cancel Import6�   �� 5   
   -   5        $��	txtOutput��5      $��4��6#   " �� VerticalScrollBarVisibility$
 Auto=�60   $ �� HorizontalScrollBarVisibility$
 Auto=�6S   ��6x   �� *
InfoText+$ OneWay=�6�   � 5    
   -   5        $��importProgressBar��5    �   $��5��6   $��Stretch=�6a   $��2,2,2,2q�6    � Maximum 6#   �� *
MaxRecords+ � Value 6B   �� *RecordNumber+6�   5!      5"      