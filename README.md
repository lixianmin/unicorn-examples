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
      3. Clipipling Planes: -100 ~ 100
   3. Rendering:
      1. Clear Depth: ✓
      2. Culling Mask: UI
2. 在场景中找到Main Camera节点：
   1. Render Type: Base
   2. Rendering:
      1. Culling Mask: 把UI剔除
   3. Stack: 添加UICamera
3. 在场景中创建一个名为UIRoot的Canvas节点：
   1. Render Mode：Screen Space - Camera
   2. Render Camera：UICamera



然后，通过`UIManager.Instance.OpenWindow(typeof(UIBag))`打开的界面，会在UIRoot节点下找到



##### 2 如何制作3D的UI

3D的UI可以跟2D的UI一样通过addressable动态加载到场景中，但也可以在加载场景时随场景预加载，这样就不需要动态加载了

制作流程为：

1. 3D的UI不需要独立的UICamera，直接在Main Camera中观察即可
2. UIRoot不需要



#### 3 FAQ

##### 1 已完成的UI的脚本丢失

如果uibag等prefab上的脚本丢失，这是因为Unicorn.dll是先于ugui的代码导入的，解决方法为：选中Unicorn.dll → 右键Reimport



#### 3 Roadmap

1. MVC流程
2. Metadata使用流程
3. Kit解耦方案
4. UI本地化支持
