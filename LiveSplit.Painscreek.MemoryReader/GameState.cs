
// <Elements>
//   <Element Offset="16" Vartype="4 Bytes" Bytesize="4" OffsetHex="00000010" Description="m_InstanceID" DisplayMethod="unsigned integer"/>
//   <Element Offset="24" Vartype="Pointer" Bytesize="8" OffsetHex="00000018" Description="m_CachedPtr" DisplayMethod="unsigned integer"/>
//   <Element Offset="32" Vartype="Pointer" Bytesize="8" OffsetHex="00000020" Description="player" DisplayMethod="unsigned integer"/>
//   <Element Offset="40" Vartype="Pointer" Bytesize="8" OffsetHex="00000028" Description="rewiredPlayer" DisplayMethod="unsigned integer"/>
//   <Element Offset="48" Vartype="Pointer" Bytesize="8" OffsetHex="00000030" Description="checkList" DisplayMethod="unsigned integer"/>
//   <Element Offset="56" Vartype="Pointer" Bytesize="8" OffsetHex="00000038" Description="lockedOne" DisplayMethod="unsigned integer"/>
//   <Element Offset="64" Vartype="Pointer" Bytesize="8" OffsetHex="00000040" Description="messageText" DisplayMethod="unsigned integer"/>
//   <Element Offset="72" Vartype="Pointer" Bytesize="8" OffsetHex="00000048" Description="naviMessageText" DisplayMethod="unsigned integer"/>
//   <Element Offset="80" Vartype="Pointer" Bytesize="8" OffsetHex="00000050" Description="anim" DisplayMethod="unsigned integer"/>
//   <Element Offset="88" Vartype="Pointer" Bytesize="8" OffsetHex="00000058" Description="fadeIn" DisplayMethod="unsigned integer"/>
//   <Element Offset="96" Vartype="Pointer" Bytesize="8" OffsetHex="00000060" Description="fadeOut" DisplayMethod="unsigned integer"/>
//   <Element Offset="104" Vartype="Pointer" Bytesize="8" OffsetHex="00000068" Description="editorletter" DisplayMethod="unsigned integer"/>
//   <Element Offset="112" Vartype="Pointer" Bytesize="8" OffsetHex="00000070" Description="memo" DisplayMethod="unsigned integer"/>
//   <Element Offset="120" Vartype="Pointer" Bytesize="8" OffsetHex="00000078" Description="triggers" DisplayMethod="unsigned integer"/>
//   <Element Offset="128" Vartype="Pointer" Bytesize="8" OffsetHex="00000080" Description="zoomTrigger" DisplayMethod="unsigned integer"/>
//   <Element Offset="136" Vartype="Pointer" Bytesize="8" OffsetHex="00000088" Description="crouchTrigger" DisplayMethod="unsigned integer"/>
//   <Element Offset="144" Vartype="Pointer" Bytesize="8" OffsetHex="00000090" Description="sprintTrigger" DisplayMethod="unsigned integer"/>
//   <Element Offset="152" Vartype="Pointer" Bytesize="8" OffsetHex="00000098" Description="horizontal" DisplayMethod="unsigned integer"/>
//   <Element Offset="160" Vartype="Pointer" Bytesize="8" OffsetHex="000000A0" Description="vertical" DisplayMethod="unsigned integer"/>
//   <Element Offset="168" Vartype="Pointer" Bytesize="8" OffsetHex="000000A8" Description="forward" DisplayMethod="unsigned integer"/>
//   <Element Offset="176" Vartype="Pointer" Bytesize="8" OffsetHex="000000B0" Description="back" DisplayMethod="unsigned integer"/>
//   <Element Offset="184" Vartype="Pointer" Bytesize="8" OffsetHex="000000B8" Description="left" DisplayMethod="unsigned integer"/>
//   <Element Offset="192" Vartype="Pointer" Bytesize="8" OffsetHex="000000C0" Description="right" DisplayMethod="unsigned integer"/>
//   <Element Offset="200" Vartype="4 Bytes" Bytesize="4" OffsetHex="000000C8" Description="playerId" DisplayMethod="unsigned integer"/>
//   <Element Offset="204" Vartype="4 Bytes" Bytesize="4" OffsetHex="000000CC" Description="checkCount" DisplayMethod="unsigned integer"/>
//   <Element Offset="208" Vartype="Byte" Bytesize="1" OffsetHex="000000D0" Description="tutorialON" DisplayMethod="unsigned integer"/>
//   <Element Offset="209" Vartype="Byte" Bytesize="1" OffsetHex="000000D1" Description="SO_tutorio" DisplayMethod="unsigned integer"/>
//   <Element Offset="210" Vartype="Byte" Bytesize="1" OffsetHex="000000D2" Description="firstPlay" DisplayMethod="unsigned integer"/>
//   <Element Offset="211" Vartype="Byte" Bytesize="1" OffsetHex="000000D3" Description="openNote" DisplayMethod="unsigned integer"/>
//   <Element Offset="212" Vartype="Byte" Bytesize="1" OffsetHex="000000D4" Description="messageON" DisplayMethod="unsigned integer"/>
//   <Element Offset="216" Vartype="Float" Bytesize="4" OffsetHex="000000D8" Description="messageOnTime" DisplayMethod="unsigned integer"/>
//   <Element Offset="220" Vartype="Float" Bytesize="4" OffsetHex="000000DC" Description="t" DisplayMethod="unsigned integer"/>
//   <Element Offset="224" Vartype="Byte" Bytesize="1" OffsetHex="000000E0" Description="interactNaviOn" DisplayMethod="unsigned integer"/>
//   <Element Offset="225" Vartype="Byte" Bytesize="1" OffsetHex="000000E1" Description="accesscameraNaviOn" DisplayMethod="unsigned integer"/>
//   <Element Offset="226" Vartype="Byte" Bytesize="1" OffsetHex="000000E2" Description="cameraNaviOn" DisplayMethod="unsigned integer"/>
//   <Element Offset="227" Vartype="Byte" Bytesize="1" OffsetHex="000000E3" Description="itemObserveNaviOn" DisplayMethod="unsigned integer"/>
//   <Element Offset="228" Vartype="Byte" Bytesize="1" OffsetHex="000000E4" Description="lockNaviOn" DisplayMethod="unsigned integer"/>
// </Elements>


// <Elements>
//   <Element Offset="16" Vartype="4 Bytes" Bytesize="4" OffsetHex="00000010" Description="m_InstanceID" DisplayMethod="unsigned integer"/>
//   <Element Offset="24" Vartype="Pointer" Bytesize="8" OffsetHex="00000018" Description="m_CachedPtr" DisplayMethod="unsigned integer"/>
//   <Element Offset="32" Vartype="Pointer" Bytesize="8" OffsetHex="00000020" ChildStruct="PlayerControl.Static" Description="item" DisplayMethod="unsigned integer"/>
//   <Element Offset="40" Vartype="Pointer" Bytesize="8" OffsetHex="00000028" ChildStruct="PlayerControl.Static" Description="detectedLockObject" DisplayMethod="unsigned integer"/>
//   <Element Offset="48" Vartype="Pointer" Bytesize="8" OffsetHex="00000030" ChildStruct="PlayerControl.Static" Description="interactingObject" DisplayMethod="unsigned integer"/>
//   <Element Offset="56" Vartype="Pointer" Bytesize="8" OffsetHex="00000038" Description="spawnPoint" DisplayMethod="unsigned integer"/>
//   <Element Offset="64" Vartype="Pointer" Bytesize="8" OffsetHex="00000040" Description="loadingLevelName" DisplayMethod="unsigned integer"/>
//   <Element Offset="72" Vartype="Pointer" Bytesize="8" OffsetHex="00000048" ChildStruct="PlayerControl.Static" Description="SP" DisplayMethod="unsigned integer"/>
//   <Element Offset="80" Vartype="Pointer" Bytesize="8" OffsetHex="00000050" Description="deadSound" DisplayMethod="unsigned integer"/>
//   <Element Offset="88" Vartype="Pointer" Bytesize="8" OffsetHex="00000058" ChildStruct="PlayerControl.Static" Description="deadSound_mixer" DisplayMethod="unsigned integer"/>
//   <Element Offset="96" Vartype="Pointer" Bytesize="8" OffsetHex="00000060" Description="NoSaveWarnig" DisplayMethod="unsigned integer"/>
//   <Element Offset="104" Vartype="Pointer" Bytesize="8" OffsetHex="00000068" Description="JanetCollider" DisplayMethod="unsigned integer"/>
//   <Element Offset="112" Vartype="Pointer" Bytesize="8" OffsetHex="00000070" Description="enemyOn_UI" DisplayMethod="unsigned integer"/>
//   <Element Offset="120" Vartype="Pointer" Bytesize="8" OffsetHex="00000078" Description="HeathSlider" DisplayMethod="unsigned integer"/>
//   <Element Offset="128" Vartype="Pointer" Bytesize="8" OffsetHex="00000080" Description="BloodAnim" DisplayMethod="unsigned integer"/>
//   <Element Offset="136" Vartype="Pointer" Bytesize="8" OffsetHex="00000088" ChildStruct="PlayerControl.Static" Description="currentSofiaEvent" DisplayMethod="unsigned integer"/>
//   <Element Offset="144" Vartype="Pointer" Bytesize="8" OffsetHex="00000090" Description="cursor" DisplayMethod="unsigned integer"/>
//   <Element Offset="152" Vartype="Pointer" Bytesize="8" OffsetHex="00000098" Description="cursorText" DisplayMethod="unsigned integer"/>
//   <Element Offset="160" Vartype="Pointer" Bytesize="8" OffsetHex="000000A0" Description="playerSpeech_text" DisplayMethod="unsigned integer"/>
//   <Element Offset="168" Vartype="Pointer" Bytesize="8" OffsetHex="000000A8" Description="itemMassage_text" DisplayMethod="unsigned integer"/>
//   <Element Offset="176" Vartype="Pointer" Bytesize="8" OffsetHex="000000B0" Description="fadeOutTexture" DisplayMethod="unsigned integer"/>
//   <Element Offset="184" Vartype="Pointer" Bytesize="8" OffsetHex="000000B8" Description="loadingPercentage" DisplayMethod="unsigned integer"/>
//   <Element Offset="192" Vartype="Pointer" Bytesize="8" OffsetHex="000000C0" Description="blur" DisplayMethod="unsigned integer"/>
//   <Element Offset="200" Vartype="Pointer" Bytesize="8" OffsetHex="000000C8" Description="rewiredPlayer" DisplayMethod="unsigned integer"/>
//   <Element Offset="208" Vartype="Byte" Bytesize="1" OffsetHex="000000D0" Description="developer" DisplayMethod="unsigned integer"/>
//   <Element Offset="209" Vartype="Byte" Bytesize="1" OffsetHex="000000D1" Description="Demo" DisplayMethod="unsigned integer"/>
//   <Element Offset="212" Vartype="Float" Bytesize="4" OffsetHex="000000D4" Description="currentRange" DisplayMethod="unsigned integer"/>
//   <Element Offset="216" Vartype="Float" Bytesize="4" OffsetHex="000000D8" Description="DefaultRange" DisplayMethod="unsigned integer"/>
//   <Element Offset="220" Vartype="Float" Bytesize="4" OffsetHex="000000DC" Description="upRange" DisplayMethod="unsigned integer"/>
//   <Element Offset="224" Vartype="Float" Bytesize="4" OffsetHex="000000E0" Description="downRange" DisplayMethod="unsigned integer"/>
//   <Element Offset="228" Vartype="Float" Bytesize="4" OffsetHex="000000E4" Description="range" DisplayMethod="unsigned integer"/>
//   <Element Offset="232" Vartype="Byte" Bytesize="1" OffsetHex="000000E8" Description="windowOpen" DisplayMethod="unsigned integer"/>
//   <Element Offset="236" Vartype="4 Bytes" Bytesize="4" OffsetHex="000000EC" Description="openWindowID" DisplayMethod="unsigned integer"/>
//   <Element Offset="240" Vartype="Byte" Bytesize="1" OffsetHex="000000F0" Description="switchable" DisplayMethod="unsigned integer"/>
//   <Element Offset="241" Vartype="Byte" Bytesize="1" OffsetHex="000000F1" Description="accessOn" DisplayMethod="unsigned integer"/>
//   <Element Offset="242" Vartype="Byte" Bytesize="1" OffsetHex="000000F2" Description="inventoryOn" DisplayMethod="unsigned integer"/>
//   <Element Offset="243" Vartype="Byte" Bytesize="1" OffsetHex="000000F3" Description="journalOn" DisplayMethod="unsigned integer"/>
//   <Element Offset="244" Vartype="Byte" Bytesize="1" OffsetHex="000000F4" Description="photoOn" DisplayMethod="unsigned integer"/>
//   <Element Offset="245" Vartype="Byte" Bytesize="1" OffsetHex="000000F5" Description="cameraOn" DisplayMethod="unsigned integer"/>
//   <Element Offset="246" Vartype="Byte" Bytesize="1" OffsetHex="000000F6" Description="itemObserveOn" DisplayMethod="unsigned integer"/>
//   <Element Offset="247" Vartype="Byte" Bytesize="1" OffsetHex="000000F7" Description="reading" DisplayMethod="unsigned integer"/>
//   <Element Offset="248" Vartype="Byte" Bytesize="1" OffsetHex="000000F8" Description="listening" DisplayMethod="unsigned integer"/>
//   <Element Offset="249" Vartype="Byte" Bytesize="1" OffsetHex="000000F9" Description="interacting" DisplayMethod="unsigned integer"/>
//   <Element Offset="250" Vartype="Byte" Bytesize="1" OffsetHex="000000FA" Description="onMouseMessaging" DisplayMethod="unsigned integer"/>
//   <Element Offset="251" Vartype="Byte" Bytesize="1" OffsetHex="000000FB" Description="PauseMenuOn" DisplayMethod="unsigned integer"/>
//   <Element Offset="252" Vartype="Byte" Bytesize="1" OffsetHex="000000FC" Description="OptionMenuOn" DisplayMethod="unsigned integer"/>
//   <Element Offset="253" Vartype="Byte" Bytesize="1" OffsetHex="000000FD" Description="StartMenuOn" DisplayMethod="unsigned integer"/>
//   <Element Offset="254" Vartype="Byte" Bytesize="1" OffsetHex="000000FE" Description="prolougeOn" DisplayMethod="unsigned integer"/>
//   <Element Offset="255" Vartype="Byte" Bytesize="1" OffsetHex="000000FF" Description="levelLoading" DisplayMethod="unsigned integer"/>
//   <Element Offset="256" Vartype="Byte" Bytesize="1" OffsetHex="00000100" Description="loading" DisplayMethod="unsigned integer"/>
//   <Element Offset="257" Vartype="Byte" Bytesize="1" OffsetHex="00000101" Description="puzzleOn" DisplayMethod="unsigned integer"/>
//   <Element Offset="258" Vartype="Byte" Bytesize="1" OffsetHex="00000102" Description="detectLock" DisplayMethod="unsigned integer"/>
//   <Element Offset="259" Vartype="Byte" Bytesize="1" OffsetHex="00000103" Description="unlocking" DisplayMethod="unsigned integer"/>
//   <Element Offset="260" Vartype="Byte" Bytesize="1" OffsetHex="00000104" Description="messageOn" DisplayMethod="unsigned integer"/>
//   <Element Offset="261" Vartype="Byte" Bytesize="1" OffsetHex="00000105" Description="mapOn" DisplayMethod="unsigned integer"/>
//   <Element Offset="262" Vartype="Byte" Bytesize="1" OffsetHex="00000106" Description="leavingVillage" DisplayMethod="unsigned integer"/>
//   <Element Offset="263" Vartype="Byte" Bytesize="1" OffsetHex="00000107" Description="Ending" DisplayMethod="unsigned integer"/>
//   <Element Offset="264" Vartype="4 Bytes" Bytesize="4" OffsetHex="00000108" Description="playerEndingPath" DisplayMethod="unsigned integer"/>
//   <Element Offset="268" Vartype="Byte" Bytesize="1" OffsetHex="0000010C" Description="LoadingActive" DisplayMethod="unsigned integer"/>
//   <Element Offset="269" Vartype="Byte" Bytesize="1" OffsetHex="0000010D" Description="enemy" DisplayMethod="unsigned integer"/>
//   <Element Offset="270" Vartype="Byte" Bytesize="1" OffsetHex="0000010E" Description="dead" DisplayMethod="unsigned integer"/>
//   <Element Offset="272" Vartype="4 Bytes" Bytesize="4" OffsetHex="00000110" Description="DamageCount" DisplayMethod="unsigned integer"/>
//   <Element Offset="276" Vartype="Byte" Bytesize="1" OffsetHex="00000114" Description="enemyPause" DisplayMethod="unsigned integer"/>
//   <Element Offset="280" Vartype="Float" Bytesize="4" OffsetHex="00000118" Description="bloodanimTime" DisplayMethod="unsigned integer"/>
//   <Element Offset="284" Vartype="Float" Bytesize="4" OffsetHex="0000011C" Description="warningTime" DisplayMethod="unsigned integer"/>
//   <Element Offset="288" Vartype="4 Bytes" Bytesize="4" OffsetHex="00000120" Description="playerDeadEnding" DisplayMethod="unsigned integer"/>
//   <Element Offset="292" Vartype="Byte" Bytesize="1" OffsetHex="00000124" Description="SofiaOn" DisplayMethod="unsigned integer"/>
//   <Element Offset="296" Vartype="Float" Bytesize="4" OffsetHex="00000128" Description="fadeTime" DisplayMethod="unsigned integer"/>
//   <Element Offset="300" Vartype="Float" Bytesize="4" OffsetHex="0000012C" Description="timeOffset" DisplayMethod="unsigned integer"/>
//   <Element Offset="304" Vartype="Byte" Bytesize="1" OffsetHex="00000130" Description="achievementActive" DisplayMethod="unsigned integer"/>
//   <Element Offset="308" Vartype="4 Bytes" Bytesize="4" OffsetHex="00000134" Description="playerId" DisplayMethod="unsigned integer"/>
//   <Element Offset="312" Vartype="Byte" Bytesize="1" OffsetHex="00000138" Description="z" DisplayMethod="unsigned integer"/>
//   <Element Offset="316" Vartype="Float" Bytesize="4" OffsetHex="0000013C" Description="currentsens" DisplayMethod="unsigned integer"/>
// </Elements>


namespace LiveSplit.Painscreek.MemoryReader
{
  public struct GameState
  {
    // Whether the pause menu is on
    public bool IsPaused;
    // 0x100 loading flag
    // Is set to true after unloading, set to false before fade-in
    public bool DoNotUse_IsLoading;
    // 0xFF levelLoading flag
    // Is set to true on fade-outs and to false on fade-ins
    public bool IsInSceneTransition;
    // 0x10C LoadingActive flag
    // Set before loading screen. Do not use as it is only set temporarily
    // and reset quite immediatelly on Loading:LoadLevel
    public bool DoNotUse_LoadingActive;
    // The post-game scene with the score
    public bool IsEndingScene;
    // The initial call, Hey Janet...
    public bool IsPrologueScene;
    // The start screen on boot up
    public bool IsStartMenu;
    // The ending that is gonna be loaded up
    // 0 == none
    // 1 == journalist missing
    // 2 == matthew died
    // 3 == questioner
    // 4 == demo
    public int EndingPath;
    public bool IsInteracting;
    public bool IsItemObserveOn;
    public bool IsWindowOpen;
    public int OpenWindowID;
    public bool IsFlashlightComponentDisabled;
    public bool IsTutorialOn;
  }
}
