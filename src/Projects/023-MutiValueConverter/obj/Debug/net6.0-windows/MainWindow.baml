   M S B A M L   `   `   `  ����M  IMutiValueConverter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MutiValueConverterMutiValueConverter  5   	   M+clr-namespace:MutiValueConverter.ConvertersMutiValueConverter.Converters  5   	   #    MutiValueConverter.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:MutiValueConverter     5   	   B
converters+clr-namespace:MutiValueConverter.Converters     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)    � 	Resources 5
      5   /MutiValueConverter.Converters.FullnameConverter   FullnameConverter��%   &	          5   
   6'   5      .��5      ��  �� Orientation$ Vertical=�6   .+�5   
   �� -   5         ��Name$ m_textBoxFirstname��5      6.   �� 5   
   -   5        $ m_textBoxMiddlename��5      6/   �� 5   
   -   5        $ m_textBoxFamilyname��5      6/   �� 5   
   -   5        $ m_textBoxFullname��5      .��6G   ��5      `� 5       `� 	Converter# [  6   .1�5      ��  �� ElementName$ m_textBoxFirstname��6    �� Path$
 Text�6?    �� Mode$ TwoWay=�6K   �� 5      $ m_textBoxMiddlename��6   $
 Text�6@   $ TwoWay=�6L   �� 5      $ m_textBoxFamilyname��6   $
 Text�6@   $ TwoWay=�6L   5      .��5      5      5      5      