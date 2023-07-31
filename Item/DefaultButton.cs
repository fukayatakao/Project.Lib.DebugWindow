using UnityEngine;
using System.Collections.Generic;

namespace Project.Lib {
#if DEVELOP_BUILD
 	/// <summary>
	/// 通常ボタン
	/// </summary>
    public class ButtonNormal {
        /// <summary>
        /// UI表示
        /// </summary>
        public static void Draw(string text, System.Action action) {
            if (FitGUILayout.Button(text)) {
                action();
            }
        }

        public static bool Draw(string text) {
            return FitGUILayout.Button(text);
        }
    }

    /// <summary>
    /// 新規ウィンドウを開く
    /// </summary>
    public class ButtonOpenWindow {
        /// <summary>
        /// UI表示
        /// </summary>
        public static void Draw<T>(string text) where T : DebugWindow, new(){
            if (FitGUILayout.Button(text)) {
                DebugWindowManager.Open<T>();
            }
        }
    }
	/// <summary>
	/// メインウィンドウを切り替え
	/// </summary>
    public class ButtonChangeWindow {
        /// <summary>
        /// UI表示
        /// </summary>
        public static void Draw<T>(string text) where T : DebugWindow, new() {
            if (FitGUILayout.Button(text)) {
                DebugWindowManager.Change<T>();
            }
        }
    }

    /// <summary>
    /// on/offスイッチボタン
    /// </summary>
    public class ButtonSwitch {
		static readonly string[] ButtonText = new string[] { "on", "off" };

        /// <summary>
        /// UI表示
        /// </summary>
		public static bool Draw(bool enable, string caption, System.Action on=null, System.Action off=null) {
			if (!string.IsNullOrEmpty(caption)) {
				FitGUILayout.Label(caption);
			}
			using (new GUILayout.HorizontalScope()) {
				Color col = GUI.color;
				if (enable) {
					GUI.color = Color.red;
				}
				if (FitGUILayout.Button("on")) {
                    if(on != null)
    					on();
					enable = true;
				}
				GUI.color = col;
				if (!enable) {
					GUI.color = Color.blue;
				}
				if(FitGUILayout.Button("off")) {
                    if (off != null)
                        off();
                    enable = false;
				}
				GUI.color = col;
			}

			return enable;
        }
    }

#endif
}


