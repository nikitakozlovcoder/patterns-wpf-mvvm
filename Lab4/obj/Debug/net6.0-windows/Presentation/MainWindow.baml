   M S B A M L   `   `   `  ����?  ;Lab4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Lab4.ViewModelsLab4.ViewModels  5   	   U QSystem.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a7,clr-namespace:System;assembly=System.RuntimeSystem 5   	   9!clr-namespace:Lab4.Core.ConstantsLab4.Core.Constants  5	   	   9!clr-namespace:Lab4.Lib.ConvertersLab4.Lib.Converters  5
   	   "    Lab4.Presentation.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4
viewModelsclr-namespace:Lab4.ViewModels     5   	   ?system,clr-namespace:System;assembly=System.Runtime     5   	   7	constants!clr-namespace:Lab4.Core.Constants     5	   	   8
converters!clr-namespace:Lab4.Lib.Converters     5
   	   $��22(�5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5      *   $Lab4.ViewModels.ApplicationViewModel  5   
    � 	Resources 5      )   #Lab4.Lib.Converters.IsNullConverter   IsNullConverter  LoadTypeValues S� 
MethodName S� 
ObjectType  System.Enum S� MethodParameters M� TypeName��%�   &	        &	        5   
   6%   S� 5   
   $ 	GetValues��64   "  5       5      M� 5      $ constants:ELoadType��6   5      5      .��5      �� .��5      �� .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $
��Left=�6   $��5 5 5 25q�65   .+�5      �� $��0 5 0 5q�6   $
��Name��6-   �� 5      ��6   ��  �� Path$ NewShipRequest.Name�	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� Mode$
 TwoWay=��� 5      $��	0 15 0  0q�6   $ 
Horizontal=�60   $��Center=�6I   .+�5       �� $��0 5 0 5q�6    $��	Is loaded��61   �� 5!      $��	15 0 0 0 q�6   $��Center=�62    d� 	IsChecked 6M   �� $ NewShipRequest.IsLoaded�$
 TwoWay=�5"      �� 5#      ��6   ��  �� Source# [  �� SelectedItem 5$      �� $ NewShipRequest.ELoadType�$
 TwoWay=��� 5%      $��0 15 0 0q�6   $��Add ship��6+   $��40��6>   $	��250��6J   ��6V   �� *AddShipCommand+5&      �� 5'      $��	40 40 0 0q�6   .+�5(      �� $��Notify weather changed��6   $��40��6:   $	��250��6F   ��6R   �� *NotifyChangeWeather+�� 5)      $��26(�6   
���  ��$
��Bold"�6;   $��0 8 0 0q�6M   Bad weather alert��5+      �� 5,       �� 
TargetType" ��6     �� Triggers 5-      �� 5.   "   &    Lab4.Core.Constants.EWeatherType   Good �� Value# Z 6N    �� Binding 6.   �� *WeatherType+.a�5/   &   ��  �� Property � y� �� Value$ Hidden=�6C   50   #   �� 51   "   
   Bad# Z 6N    6.   �� *WeatherType+.a�52   &   ��  � y�$ Visible=�6C   53   #   55      57      58      �� 59      $��	40 40 0 0q�6   $	��Top=�6(   $��Static/logo.jpg��6@   $	��400��6Y   $	��400��6e   5:      � 5;   
   $	��100��6    � ColumnDefinitions 5<      �� 5=      $��* �6#   �� 5>      $��* �6#   �� 5?      $��* �6#   .+�5A      �� $��
 5 0  5 0 q�6    �� CornerRadius$ 6��6)   
�������
�������$��2q�6`   $	��Top=�6t   ._�5B      �� $��Center=�6   $��Center=�66   .+�5C      �� Gas ship yard6+   � 5D      .+�5E      �� $��20(�6   Free��5G      �� 5H      " ��6     5I      �� 5J   "    6.   �� *$"ShipYardVm.GasShipYard.CurrentShip+ �� 	Converter# [  	 False6�   .a�5K   &   ��  � y�$ Hidden=�6C   5L   #   5N      5P      �� 5Q      ��6   �� *)'ShipYardVm.GasShipYard.CurrentShip.Name+5R      5S      5T      �� 5U      $��1��6   $��
 5 0  5 0 q�6%   $ 6��69   
�������
�������$��2q�6p   $	��Top=�6�   ._�5V      �� $��Center=�6   $��Center=�66   .+�5W      �� Water ship yard6-   � 5X      .+�5Y      �� $��20(�6   Free��5[      �� 5\      " ��6     5]      �� 5^   "    6.   �� *&$ShipYardVm.WaterShipYard.CurrentShip+# [  	 False6�   .a�5_   &   ��  � y�$ Hidden=�6C   5`   #   5b      5d      �� 5e      ��6   �� *+)ShipYardVm.WaterShipYard.CurrentShip.Name+5f      5g      5h      �� 5i      $��2��6   $��
 5 0  5 0 q�6%   $ 6��69   
�������
�������$��2q�6p   $	��Top=�6�   ._�5j      �� $��Center=�6   $��Center=�66   .+�5k      �� Oil ship yard6+   � 5l      .+�5m      �� $��20(�6   Free��5o      �� 5p      " ��6     5q      �� 5r   "    6.   �� *$"ShipYardVm.OilShipYard.CurrentShip+# [  	 False6�   .a�5s   &   ��  � y�$ Hidden=�6C   5t   #   5v      5x      �� 5y      ��6   �� *)'ShipYardVm.OilShipYard.CurrentShip.Name+5z      5{      5|      5}      � 5~   
   $��
 0 25 0 20q�6    5      �� 5�      $��* �6#   �� 5�      $
��0.8* �6#   .+�5�      �� $��0��6   ��6&   �� *ShipDispatcher.Ships+ 6S   �� *SelectedShip+��5�      �� 5�      .R�5�      �� $��5q�6%   .+�5�      �� $��Name:��6(   �� 5�      $��10 0 0 0q�6(   ��6:   �� $
 Name�5�      5�      5�      �� 5�      $
��Left=�6   $��1��64   $��25 0 0 0q�6D   .+�5�      �� $
��Name��6   �� 5�      $
��Bold"�6   ��6.   �� *SelectedShip.Name+ �� FallbackValue$	 ---���� 5�      $��0 15 0 0q�6   $��	Is loaded��6/   �� 5�      $
��Bold"�6   ��6.   �� *SelectedShip.IsLoaded+$	 ---���� 5�      $��0 15 0 0q�6   $��	Load type��6/   �� 5�      $
��Bold"�6   ��6.   �� *SelectedShip.ELoadType+$	 ---���� 5�      $
��Bold"�6   $��0 15 0 0q�6.   ��6@   �� *SelectedShip.Status+�� 5�      $��0 15 0 0q�6   $��Change state��6+   $��45��6B   $	��250��6N   ��6Z   �� *ChangeShipState+�� 5�      $��0 15 0 0q�6   $��Delete ship��6+   $��45��6A   $	��250��6M   ��6Y   �� *
DeleteShip+5�      5�      5�      5�      5�      