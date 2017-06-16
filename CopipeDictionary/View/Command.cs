using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CopipeDictionary.View
{
    public class Command : ICommand
    {
        /// <summary>
        /// コマンドを実行するかどうかに影響するような変更があった場合に発生します。
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// コマンド実行時に呼び出すアクション
        /// </summary>
        private readonly Action<object> _commandExecuted;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="commandExecuted">コマンド実行時に呼び出すアクション</param>
        public Command(Action commandExecuted)
        {
            this._commandExecuted = (parameter => commandExecuted());
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="commandExecuted">コマンド実行時に呼び出すアクション</param>
        public Command(Action<object> commandExecuted)
        {
            this._commandExecuted = commandExecuted;
        }

        /// <summary>
        /// 現在の状態でコマンドが実行可能かどうかを決定するメソッドを定義します。
        /// </summary>
        /// <param name="parameter">コマンドにより使用されるデータです。コマンドにデータを渡す必要がない場合は、このオブジェクトを null に設定できます。</param>
        /// <returns>このコマンドを実行できる場合は true。それ以外の場合は false。</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// コマンドが起動される際に呼び出すメソッドを定義します。
        /// </summary>
        /// <param name="parameter">コマンドにより使用されるデータです。コマンドにデータを渡す必要がない場合は、このオブジェクトを null に設定できます。</param>
        public void Execute(object parameter)
        {
            this._commandExecuted(parameter);
        }
    }
}
