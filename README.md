#### 1 unicorn-examples



unicorn代码库使用方法教程，包括：

1. UIManager：UI框架
2. Metadata：配置管理
3. WebManager：资源加载



#### 2 URP管线中如何制作UI界面

##### 1 设置Camera

制作UI之前，需要先设置好UICamera（用于显示2D界面）与Main Camera（用于显示3D界面）



1. 在场景中创建一个名为**UICamera**的节点，添加Camera组件，删除Listener组件：
   1. Render Type: Overlay
   2. Projection: 
      1. Projection: Orthographic
      2. Size: 5
      3. Clipipling Planes: [-100, 100]
   3. Rendering:
      1. Clear Depth: ✓
      2. Culling Mask: UI
2. 在场景中找到**Main Camera**节点：
   1. Render Type: Base
   2. Rendering:
      1. Culling Mask: 把UI剔除
   3. Stack: 添加UICamera
3. 在场景中创建一个名为UIRoot的空节点



##### 2 如何制作2D界面

1. 在Hierarchy窗口中，右键UIRoot，选择UI→UI Canvas，设置Canvas组件的Render Mode为Screen Space - Camera，命名为uibag
2. 右键uibag，选择UI→UI Panel，创建窗体背景面板。Panel=背景+鼠标事件拦截，但不是必须的
3. 在panel下面可以创建各类UI控件，从而完成窗体样式的创建
4. 如果需要窗体打开/关闭动画，则需要在uibag上加UISerializer组件，并完善Open Window Animaion和Close Window Animation



```c#

public class UIBag: UIWindowBase
{
  	// 如果UIRoot的直接子节点存在以assetPath命名的Canvas节点，则直接使用该节点，这意味着UI界面是随场景加载进来的
  	// 否则assetPath被当作UI资源的路径，会动态从addressable加载
    public override string GetAssetPath()
    {
       return "Assets/res/prefabs/ui/uibag.prefab";
    }
}

// 打开UI
UIManager.Instance.OpenWindow(typeof(UIBag));

// 关闭UI
UIManager.Instance.CloseWindow(typeof(UIBag));
```



##### 3 如何制作3D界面

3D界面与2D界面的制作过程几乎完全一样，唯一的区别是Canvas设置有些不同：

1. 设置Canvas组件的Render Mode为World Space，这是因为界面需要在3D场景中显示
2. RectTransform：修改Scale到合适大小，我习惯设置为0.01；PosX, PosY, PosZ代表窗体在场景中的位置，可先重置为(0, 0, 0)再调整



#### 3 FAQ

##### 1 已完成的UI的脚本丢失

如果uibag等prefab上的脚本丢失，这是因为Unicorn.dll是先于ugui的代码导入的，解决方法为：选中Unicorn.dll → 右键Reimport



#### 3 Roadmap

1. MVC流程
2. Metadata使用流程
3. Kit解耦方案
4. UI本地化支持
