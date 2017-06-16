using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Windows.ApplicationModel.DataTransfer;

namespace CopipeDictionary.View
{
    /// <summary>
    /// メインページのビューモデル
    /// </summary>
    public class MainPageViewModel
    {
        /// <summary>
        /// リストに表示するテキストの一覧
        /// </summary>
        public ObservableCollection<StringItem> StringList { get; private set; }
        /// <summary>
        /// リストのボタン押下時のコマンド
        /// </summary>
        public Command ListItemButtonCommand { get; private set; }
        /// <summary>
        /// アプリバー追加ボタン押下時のコマンド
        /// </summary>
        public Command AppBarAddButtonCommand { get; private set; }

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public MainPageViewModel()
        {
            this.StringList = new ObservableCollection<StringItem>();

            this.ListItemButtonCommand = new Command(this.ListItemButton_Clicked);
            this.AppBarAddButtonCommand = new Command(this.AppBarAddButton_Clicked);
        }

        public void ListItemButton_Clicked(object item)
        {
            StringItem si = item as StringItem;
            if (null != si)
            {
                DataPackage dataPackage = new DataPackage();
                dataPackage.RequestedOperation = DataPackageOperation.Copy;
                dataPackage.SetText(si.Text);
                Clipboard.SetContent(dataPackage);
            }
        }

        /// <summary>
        /// アプリバー追加ボタン押下時に呼ばれる。
        /// </summary>
        public void AppBarAddButton_Clicked()
        {
            this.StringList.Add(new StringItem() { Text = "aaa" });
        }
    }

    public class StringItem
    {
        public string Text { get; set; }
    }
}
