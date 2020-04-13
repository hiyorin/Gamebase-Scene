# Gamebase-SceneManagement

<br><br><br><br>
## Table Of Contents
- [Description](#description)
- [Install](#install)
- [Usege](#usage)
  - [Create Application Scene](#create-application-scene)
  - [Add Scene](#add-scene)
  - [Controller](#controller)
  - [Lifecycle](#lifecycle)
- [NodeCanvas Integration](#nodecanvas-integration)
- [License](#license)

<br><br><br><br>
## Description
*Gamebase-SceneManagement* is manage scene and make  scene lifecycle.
*Gamebase-SceneManagement* is an extension for [Gamebase-Core](https://github.com/hiyorin/Gamebase-Core) and won't work without it.


<br><br><br><br>
## Install
Find `Packages/manifest.json` in your project and edit it to look like this:
```json
{
  "scopedRegistries": [
  {
    "name": "OpenUPM",
    "url": "https://package.openupm.com",
    "scopes": [
      "com.neuecc",
      "com.cysharp",
      "com.svermeulen",
      "com.coffee",
      "com.demigiant",
      ...
    ]
  }],
  "dependencies": {
    "com.coffee.git-dependency-resolver": "1.1.3",
    "com.coffee.upm-git-extension": "1.1.0-preview.12",
    "com.gamebase.scene": "https://github.com/hiyorin/Gamebase-SceneManagement.git",
    ...
  }
}
```
To update the package, change `#{version}` to the target version.  
Or, use [UpmGitExtension](https://github.com/mob-sakai/UpmGitExtension.git) to install or update the package.

<br><br><br><br>
## Usage

#### Create Application Scene
This scene is parent scene. Manage child scenes.
- Right Click in folder within the Project tag and Choose `Create/Gamebase-Scene/Application`.

#### Add Scene
This scene is child scene.
- Right Click in folder within the Project tag and Choose `Create/Gamebase-Scene/Scene`.

#### Controller
- Injection ISceneController
  ```cs
  [Inject] private ISceneController sceneController = default;
  ```
- Change Scene
  ```cs
  sceneController.Change("scene name", "trand data");
  ```
  
#### Lifecycle
- ISceneLifecycle implementation
  ```cs
  public sealed class SceneLifecycleImpl : MonoBeheviour, ISceneLifecycle
  {
    async UniTask ISceneLifecycle.OnInitialize(object transData)
    {
      // Called only once when the scene is loaded.
      // Received trans data.
      // Load dynamic resources here.
    }
  
    void ISceneLifecycle.OnDispose()
    {
      // Called only onece when the scene is unloaded.
      // Unload dynamic resources here.
    }
  }
  ```
- Binding ISceneLifecycle instance
  ```cs
  public sealed class TestInstaller : MonoInstaller
  {
    [SerializeField] private SceneLifecycleImple scene = default;
    
    public override void InstallBindings()
    {
      Container.Bind<ISceneLifecycle>().FromInstance(scene).AsSingle();
    }
  }
  ```

<br><br><br><br>
## NodeCanvas Integration
[NodeCanvas](https://assetstore.unity.com/packages/tools/visual-scripting/nodecanvas-14914) is the Complete Visual Behaviour Authoring solution for Unity. For more details see the [NodeCanvas docs](https://nodecanvas.paradoxnotion.com/documentation/).  

Gamebase integration with NodeCanvas is disabled by default. To enable, you must add the define `GAMEBASE_ADD_NODECANVAS` to your project,

<br><br><br><br>
## License
This library is under the MIT License.  
[here](LICENSE.md)