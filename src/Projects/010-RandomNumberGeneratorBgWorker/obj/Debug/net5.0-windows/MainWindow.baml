   M S B A M L   `   `   `  ����P  LRandomNumberGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:RandomNumberGeneratorRandomNumberGenerator  5   	   &     RandomNumberGenerator.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:RandomNumberGenerator     5   	     � Title$  
MainWindow��5   	   $	��300��6   $	��450��6)   .��5	      ��  �� Orientation$ Vertical=�6   .+�5
   
   �� $ 
Horizontal=�6   .+�5      �� $	��Min��6   $��16(�6"   $��30��60   $	��100��6<   �� 5      -   5         ��Name$ m_textBoxMin��5      $	��300��6,   5      �� 5   
   $ 
Horizontal=�6   .+�5      �� $	��Max��6   $��16(�6"   $��30��60   $	��100��6<   �� 5      -   5        $ m_textBoxMax��5      $	��300��6F   5      �� 5   
   $ 
Horizontal=�6   .+�5      �� $��Count��6   $��16(�6$   $��30��62   $	��100��6>   �� 5      -   5        $ m_textBoxCount��5      $	��300��6.   5      �� 5   
   -   5         ��Name$ m_labelNumbers��5      $��16(�6(   $��30��66   �� 5   
   -   5        $ m_labelResult��5      $��16(�6'   $��30��65   �� 5   
   -   5         ��Name$ 
m_buttonOK��5      $��OK��6&   63   �� 5   
   -   5        $ m_buttonCancel��5      $��Cancel��6)   6:   �� 5   
   -   5        $ m_buttonExit��5      $
��Exit��6'   66   � 5   
   -	   5         �Name$ m_progressBarStatus��5       � Minimum$ 0Q�63    � Maximum$	 100Q�6?    � Value$ 0Q�6M   $��30��6W   5      5       