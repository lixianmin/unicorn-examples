#### 1 unicorn-examples



unicorn代码库使用方法教程，包括：

1. UIManager：UI框架
2. Metadata：配置管理
3. WebManager：资源加载



#### 2 Tutorial

##### 1 如何制作2D的UI

1. 在场景中创建一个名为UICamera的节点，添加Camera组件，删除Listener组件：
   1. Render Type: Overlay
   2. Projection: 
      1. Projection: Orthographic
      2. Size: 5
      3. Clipipling Planes: [-100, 100]
   3. Rendering:
      1. Clear Depth: ✓
      2. Culling Mask: UI
2. 在场景中找到Main Camera节点：
   1. Render Type: Base
   2. Rendering:
      1. Culling Mask: 把UI剔除
   3. Stack: 添加UICamera
3. 在场景中创建一个名为UIRoot的空节点，然后通过`UIManager.Instance.OpenWindow(typeof(UIBag))`打开的界面，会在UIRoot节点下找到



##### 2 如何制作3D的UI

3D的UI可以跟2D的UI一样通过addressable动态加载到场景中，但也可以随场景预加载，这样就不需要动态加载了。



制作流程为：

1. 按2D的UI的制作流程，在场景中设置Main Camera, UICamera与空的UIRoot节点
2. 然后在UIRoot下创建Canvas节点，假定命名为uishop
   1. Canvas: 修改Render Mode为WorldSpace
   2. RectTransform: 修改Scale为0.01；它的PosX, PosY, PosZ现在代表在场景中的位置，可以重置为(0, 0, 0)

3. Canvas下面可以加一个Panel节点，这样看起来像是有一个背景面板，但Panel节点并不是必须的



#### 3 FAQ

##### 1 已完成的UI的脚本丢失

如果uibag等prefab上的脚本丢失，这是因为Unicorn.dll是先于ugui的代码导入的，解决方法为：选中Unicorn.dll → 右键Reimport



#### 3 Roadmap

1. MVC流程
2. Metadata使用流程
3. Kit解耦方案
4. UI本地化支持
