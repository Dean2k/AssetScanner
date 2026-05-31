namespace AssetScanner.Config;

/// <summary>
/// Static whitelist data for known-good C# files from popular VRChat packages.
/// Entries contain SHA-256 hashes so exact matches are treated as FullyTrusted.
/// If a file matches by path but the hash does not match, it is treated as Modified
/// (obfuscation-only analysis) rather than bypassing detection entirely.
/// </summary>
public static class WhitelistData
{
    public static readonly WhitelistEntry[] Entries = new[]
    {
        // == Poiyomi Toon ==========================================================
        // Original entries from known-good Poiyomi Toon releases.

        new WhitelistEntry("Poiyomi Toon - Localization",
            new[] { "_PoiyomiShaders", "Scripts", "ThryEditor", "Editor", "Localization" },
            new[] { "0d5c54207ec13e6583eba4d79628539658e9d46842a17175502df9a0fdf14694" },
            (673, 674)),

        new WhitelistEntry("Poiyomi Toon - PoiOutlineUtil",
            new[] { "_PoiyomiShaders", "Scripts", "poi-tools", "Editor", "Tools and Editors", "PoiOutlineUtil" },
            new[] { "033d5681c9cda2c80b4e7af794bcb3f3f3fa06d6eb2283d97dbf413ca64cfd50" },
            (686, 687)),

        new WhitelistEntry("Poiyomi Toon - ThirdPartyIncluder",
            new[] { "_PoiyomiShaders", "Scripts", "poi-tools", "Editor", "Export Stuff", "ThirdPartyIncluder" },
            new[] { "7505b4bf8700f1119ed0960b5a1ed26433f7e0793763ff4b34ced1332f1182d6" },
            (219, 220)),

        new WhitelistEntry("Poiyomi Toon - PoiHelpers",
            new[] { "_PoiyomiShaders", "Scripts", "poi-tools", "Editor", "Helpers and Extensions", "PoiHelpers" },
            new[] { "8845fe7e02a2ff316477dd3675d7be3a6d0175d56f5ff13acefaa40e27f7620b" },
            (279, 280)),

        new WhitelistEntry("Poiyomi Toon - PoiSettingsUtility",
            new[] { "_PoiyomiShaders", "Scripts", "poi-tools", "Editor", "PoiSettingsUtility" },
            new[] { "6678e7ff492fc71ec825e34106e0986224c2f3b211cabc8433099b494e7ba08d" },
            (102, 103)),

        new WhitelistEntry("Poiyomi Toon - Presets",
            new[] { "_PoiyomiShaders", "Scripts", "ThryEditor", "Editor", "Presets" },
            new[] { "eaf18df7c3faaf699877068f0465dc850d8490622ba4668cce427cc8af5cc272" },
            (974, 975)),

        new WhitelistEntry("Poiyomi Toon - InspectorCapture",
            new[] { "_PoiyomiShaders", "Scripts", "ThryEditor", "Editor", "Debug", "InspectorCapture" },
            new[] { "45959564f26da89f04992fe2a7250b5a5135b7ca072ce86c0f5c2ece4eadf3d1" },
            (185, 186)),

        new WhitelistEntry("Poiyomi Toon - FileHelper",
            new[] { "_PoiyomiShaders", "Scripts", "ThryEditor", "Editor", "Helpers", "FileHelper" },
            new[] { "b7eb17fc7ca403caf4da4c0a559b4a81a81ec557a469698599b67c9af59b695f" },
            (137, 138)),

        new WhitelistEntry("Poiyomi Toon - TrashHandler",
            new[] { "_PoiyomiShaders", "Scripts", "ThryEditor", "Editor", "Helpers", "TrashHandler" },
            new[] { "7492e934475d95d8cf086bed99b072f38fe0f25ec11c9cf3b3cb0180df6c5667" },
            (50, 51)),

        new WhitelistEntry("Poiyomi Toon - Helper",
            new[] { "_PoiyomiShaders", "Scripts", "ThryEditor", "Editor", "Helpers", "Helper" },
            new[] { "64251b638c73a5f80ccebf2f07b8d22c9662067d8f6d0d60921423f64f35e81d" },
            (323, 324)),

        new WhitelistEntry("Poiyomi Toon - TPS Setup Wizard",
            new[] { "_PoiyomiShaders", "TPS", "Script", "Editor", "TPS_SetupWizard" },
            new[] { "b6705ff4ce73ebc7ea7cbf2617bf963a53a42378e1526565bdab6864a1fe58cf", "4082948ec50c1947dd29ebe5badbb8ce2d6e733255385a346bed9c8ccf16766c" },
            (2410, 2424)),

        new WhitelistEntry("Poiyomi Toon - ModularShadersForThryEditor",
            new[] { "_PoiyomiShaders", "Scripts", "poi-tools", "Editor", "ModularShaderStuff", "ModularShadersForThryEditor" },
            new[] { "cc2d1c7e7657985edc11d434ba5bb3b798cd8c98cde117346d6c8d3c6757b7de", "efedab74cab5c16906bdb357a581657d70629957b2bb411ec00f467db9b5df86" },
            (272, 273)),

        new WhitelistEntry("Poiyomi Toon - ShaderGenerator",
            new[] { "_PoiyomiShaders", "Scripts", "Editor", "ModularShaderSystem", "ShaderGenerator" },
            new[] { "043f53a70fdbea1edc33a119e77dc9837f7eb020b7593782609cd07245ef47d1", "37af7eedc808815583d011f5d966629b9dc4ee08686c514cd50fc55b50bcb95e" },
            (1424, 1425)),

        new WhitelistEntry("Poiyomi Toon - Migrator",
            new[] { "_PoiyomiShaders", "Scripts", "Editor", "ModularShaderSystem", "Editors", "Windows", "Migrator" },
            new[] { "544365d6b36a49dddd86099870aa243eb537824f5fc76a471c5859278321c7c5" },
            (820, 821)),

        new WhitelistEntry("Poiyomi Toon - TPS Helper",
            new[] { "_PoiyomiShaders", "TPS", "Scripts", "Editor", "Helper" },
            new[] { "aeb59bc9b82269503a384a3b4d8379f7fd967c9e5d3b880a61f484643a0c9d20", "f1474f173d15a2b1badd2e2ff9ab2e7939da971d92499dec12c8955e821f9698" },
            (181, 182)),

        new WhitelistEntry("Poiyomi Toon - TemplateCollectionAsset",
            new[] { "_PoiyomiShaders", "Scripts", "Editor", "ModularShaderSystem", "Scriptables", "TemplateCollectionAsset" },
            new[] { "f2974659e66ec768d91c093e1f59ffcb43f3e591d231e01f628fef6d5335291e" },
            (47, 48)),

        new WhitelistEntry("Poiyomi Toon - TexturePacker",
            new[] { "_PoiyomiShaders", "Scripts", "ThryEditor", "TexturePacker", "TexturePacker" },
            new[] { "4c3236f2af15a1982cee3b3f7dbe3ad72d78472eb875d06dc1cdfd03644a5619" },
            (1499, 1500)),

        new WhitelistEntry("Poiyomi Toon - HelperWeb",
            new[] { "_PoiyomiShaders", "Scripts", "ThryEditor", "Editor", "HelperWeb" },
            new[] { "6a138cf00c903d91dbf0e33e4f801573dd8d881f0790ec98859b961d57dca312" },
            (284, 285)),

        new WhitelistEntry("Poiyomi Toon - TemplateAsset",
            new[] { "_PoiyomiShaders", "Scripts", "Editor", "ModularShaderSystem", "Scriptables", "TemplateAsset" },
            new[] { "ef7c523a100bf62c6a993b5da84942547edd86aaa6097aefb070cbc330cd980d", "82171e2b1bb7ab3dc7f3eced289e45dd31d746bb870f569ed12429644acd1641" },
            (57, 58)),

        // == VRCFury ====================================================
        // SHA-256 verified whitelist entries. Computed from known-good package.

        new WhitelistEntry("VRCFury - _InternalsVisibleTo",
            new[] { "Editor-Avatars", "_InternalsVisibleTo.cs" },
            new[] { "23549589e02603fc1d1decc418d08bf501674dce56f3c0133c7ebb823e720922" }, (3, 4)),

        new WhitelistEntry("VRCFury - AnimationClipActionBuilder",
            new[] { "Editor-Avatars", "Actions", "AnimationClipActionBuilder.cs" },
            new[] { "ce7a9ad6d2db2044f2fc783f61cb68eed7e72de8dc4df493c9702586207abf27" }, (85, 86)),

        new WhitelistEntry("VRCFury - BlendshapeActionBuilder",
            new[] { "Editor-Avatars", "Actions", "BlendshapeActionBuilder.cs" },
            new[] { "649ba54f99fa06ba8124ff1e154bf4a5ea5e691a074c8b9d4ebe2bef25f8bbd5" }, (100, 101)),

        new WhitelistEntry("VRCFury - BlockBlinkingActionBuilder",
            new[] { "Editor-Avatars", "Actions", "BlockBlinkingActionBuilder.cs" },
            new[] { "b266fb8b6d64de80c6bfdb86e7ba18c7a0da34c4524971fc74528ea66630995f" }, (29, 30)),

        new WhitelistEntry("VRCFury - BlockVisemesActionBuilder",
            new[] { "Editor-Avatars", "Actions", "BlockVisemesActionBuilder.cs" },
            new[] { "c08dae05a34d1d75eef5ede6f59f3b5dd689b288cddbb0cbf8b8fd1eeb1f34f8" }, (29, 30)),

        new WhitelistEntry("VRCFury - DisableGesturesActionBuilder",
            new[] { "Editor-Avatars", "Actions", "DisableGesturesActionBuilder.cs" },
            new[] { "e71f7d7863e3531fdf21bc2728319f62bbed0aec1214e4c3544fd452d7f175f3" }, (31, 32)),

        new WhitelistEntry("VRCFury - FlipBookBuilderActionBuilder",
            new[] { "Editor-Avatars", "Actions", "FlipBookBuilderActionBuilder.cs" },
            new[] { "1999a8bb2c3439c989bd681655baeea575927ab8239d11c697ba9a7b9990bcc0" }, (74, 75)),

        new WhitelistEntry("VRCFury - MaterialPropertyActionBuilder",
            new[] { "Editor-Avatars", "Actions", "MaterialPropertyActionBuilder.cs" },
            new[] { "89da564f715ddf45f50f7adbdf2253c1efad4230a0dcb67ec4b3e239963b4ac0" }, (368, 369)),

        new WhitelistEntry("VRCFury - MaterialSwapActionBuilder",
            new[] { "Editor-Avatars", "Actions", "MaterialSwapActionBuilder.cs" },
            new[] { "e4838a5ae97ebaf09329574cf029955b0edd588d1823a7f7ff32bce368ddd2ca" }, (78, 79)),

        new WhitelistEntry("VRCFury - ObjectToggleActionBuilder",
            new[] { "Editor-Avatars", "Actions", "ObjectToggleActionBuilder.cs" },
            new[] { "b49f6372340efca8159b5ae80d279c4d9112e6b14fd8f48572b547195765b4f9" }, (59, 60)),

        new WhitelistEntry("VRCFury - PoiyomiFlipbookFrameActionBuilder",
            new[] { "Editor-Avatars", "Actions", "PoiyomiFlipbookFrameActionBuilder.cs" },
            new[] { "eee4ee0a61cc85514fa87ce4faa209ab5b84910ce5de40e065fbaa66a1e586af" }, (35, 36)),

        new WhitelistEntry("VRCFury - PoiyomiUVTileActionBuilder",
            new[] { "Editor-Avatars", "Actions", "PoiyomiUVTileActionBuilder.cs" },
            new[] { "5286791188c2bee9123e7bbf5011e087b46a5a929a5a96255e3a1374e7aa8c13" }, (55, 56)),

        new WhitelistEntry("VRCFury - ResetPhysboneActionBuilder",
            new[] { "Editor-Avatars", "Actions", "ResetPhysboneActionBuilder.cs" },
            new[] { "9b96fb68220e4dc4e1e52e6db6820e0ca701400bd445088bb136ecfad9674f3f" }, (36, 37)),

        new WhitelistEntry("VRCFury - ScaleActionBuilder",
            new[] { "Editor-Avatars", "Actions", "ScaleActionBuilder.cs" },
            new[] { "ecd773d56cf15bd5fba889ac0f3795a4b518fa94dc0220fb6151a8ca5cbc6b8f" }, (30, 31)),

        new WhitelistEntry("VRCFury - ScssShaderInventoryActionBuilder",
            new[] { "Editor-Avatars", "Actions", "ScssShaderInventoryActionBuilder.cs" },
            new[] { "ee3b241ea401526bf5b6d8fa3f9e4749f8814c269fc6b6cc0ca314878c1c5c0b" }, (36, 37)),

        new WhitelistEntry("VRCFury - SetAnFxFloatActionBuilder",
            new[] { "Editor-Avatars", "Actions", "SetAnFxFloatActionBuilder.cs" },
            new[] { "c5ee4698749122be19a76da7c933bfc058facd2e90ea0e5e844059101eb0f69e" }, (44, 45)),

        new WhitelistEntry("VRCFury - SmoothLoopActionBuilder",
            new[] { "Editor-Avatars", "Actions", "SmoothLoopActionBuilder.cs" },
            new[] { "ab78aa026ad405284e907c7fe02ed442f0b90457d64bb639496c8ace9f96149a" }, (51, 52)),

        new WhitelistEntry("VRCFury - SpsOnActionBuilder",
            new[] { "Editor-Avatars", "Actions", "SpsOnActionBuilder.cs" },
            new[] { "9afeeb401d564f08024c4d85a1b793b7566391644dd307ca1a97a685cf66cedd" }, (38, 39)),

        new WhitelistEntry("VRCFury - WorldDropActionBuilder",
            new[] { "Editor-Avatars", "Actions", "WorldDropActionBuilder.cs" },
            new[] { "0cd8e95c020a44efb8ae3f6cce50afee72b927080378e084c59959755d6ad623" }, (37, 38)),

        new WhitelistEntry("VRCFury - BadInstallDetector",
            new[] { "Editor-Avatars", "BadInstallDetector.cs" },
            new[] { "ff48beb0a7ca03c8a8de641fb36825f2d832202e3ea74e8677d21ba8ab3a2b4e" }, (29, 30)),

        new WhitelistEntry("VRCFury - SpsDepthContacts",
            new[] { "Editor-Avatars", "Builder", "Haptics", "SpsDepthContacts.cs" },
            new[] { "496be51fa0baabafc86f95c1025d467985168ebedd2340150e86c6ac1767a53f" }, (272, 273)),

        new WhitelistEntry("VRCFury - SpsUpgrader",
            new[] { "Editor-Avatars", "Builder", "Haptics", "SpsUpgrader.cs" },
            new[] { "531bae245b5495aa691e45b99ebadb4a4fcdea3f862813614e5679f3657149d3" }, (423, 424)),

        new WhitelistEntry("VRCFury - MenuSplitter",
            new[] { "Editor-Avatars", "Builder", "MenuSplitter.cs" },
            new[] { "28aa04b15bfe22ef38d5f0d1c0011ed30318a733b87a64fdaad7f32afd2dd5e3" }, (52, 53)),

        new WhitelistEntry("VRCFury - MmdUtils",
            new[] { "Editor-Avatars", "Builder", "MmdUtils.cs" },
            new[] { "da98864023ded804047a22ed2d90725c0bc5becd3eedd9a50211250d4a787ff5" }, (218, 219)),

        new WhitelistEntry("VRCFury - VRCAvatarUtils",
            new[] { "Editor-Avatars", "Builder", "VRCAvatarUtils.cs" },
            new[] { "aa510407859aa16ec4efc159e9f5a887ca64d9a222e2a5095f13bc6414be69ac" }, (156, 157)),

        new WhitelistEntry("VRCFury - VRCFArmatureUtils",
            new[] { "Editor-Avatars", "Builder", "VRCFArmatureUtils.cs" },
            new[] { "4979b4480d17d97ccccdd1fdb7c4ef15f7f3e17041de3a268605e762422c53e2" }, (164, 165)),

        new WhitelistEntry("VRCFury - VRCFObjectPathCache",
            new[] { "Editor-Avatars", "Builder", "VRCFObjectPathCache.cs" },
            new[] { "1b7d207dcb18d9397906b0b277b2c6a0f15b81c1111e8fafc4ee75e34566a2aa" }, (39, 40)),

        new WhitelistEntry("VRCFury - VRCFuryBuilder",
            new[] { "Editor-Avatars", "Builder", "VRCFuryBuilder.cs" },
            new[] { "b7a7c551daa1f9d7927cd520331836deaa524ef7c60542270ee7192653268d77" }, (228, 229)),

        new WhitelistEntry("VRCFury - VRCFuryInjectorBuilder",
            new[] { "Editor-Avatars", "Builder", "VRCFuryInjectorBuilder.cs" },
            new[] { "bd225562503b13fa6cd9e2ce9f399a6a44ae702536d5911b5f62cc57dd94df6d" }, (44, 45)),

        new WhitelistEntry("VRCFury - VRCFuryHideGizmoUnlessSelectedEditor",
            new[] { "Editor-Avatars", "Component", "VRCFuryHideGizmoUnlessSelectedEditor.cs" },
            new[] { "187235e4ed128b479a66a273d8ed5e17ad848a3723106313b87defd87af0f2db" }, (12, 13)),

        new WhitelistEntry("VRCFury - VRCFuryPlayComponentEditor",
            new[] { "Editor-Avatars", "Component", "VRCFuryPlayComponentEditor.cs" },
            new[] { "589c3bde1154b5b9b5496a772558075fd5a9b49dee59199285fc658dc0509aba" }, (18, 19)),

        new WhitelistEntry("VRCFury - AdvancedColliderBuilder",
            new[] { "Editor-Avatars", "Feature", "AdvancedColliderBuilder.cs" },
            new[] { "1e140bf91797bb70e787a55609faac91090d0bc4fdffa4a8fef0c6544191196c" }, (84, 85)),

        new WhitelistEntry("VRCFury - AnchorOverrideFixBuilder",
            new[] { "Editor-Avatars", "Feature", "AnchorOverrideFixBuilder.cs" },
            new[] { "5719e37f16b72802d637e21afa7051b9cff11d153617608850b1be235edf8d84" }, (66, 67)),

        new WhitelistEntry("VRCFury - ApplyDuringUploadBuilder",
            new[] { "Editor-Avatars", "Feature", "ApplyDuringUploadBuilder.cs" },
            new[] { "44c6dc61a61eb7bec5095e4520712e4456ef3ca3fc61601a01c15a9c1ac406e1" }, (38, 39)),

        new WhitelistEntry("VRCFury - ArmatureLinkBuilder",
            new[] { "Editor-Avatars", "Feature", "ArmatureLinkBuilder.cs" },
            new[] { "ab600081ae60fb25bfa4cda168a8897fe43f3e3711cd7476d28f443d3f56e48d" }, (351, 352)),

        new WhitelistEntry("VRCFury - AvatarScaleBuilder",
            new[] { "Editor-Avatars", "Feature", "AvatarScaleBuilder.cs" },
            new[] { "82c740ac23f16250e89543bd9ba40f26470af486e2d05ce433d0f8535be0da60" }, (20, 21)),

        new WhitelistEntry("VRCFury - FeatureBuilderAction",
            new[] { "Editor-Avatars", "Feature", "Base", "FeatureBuilderAction.cs" },
            new[] { "242fa838bfe7a5fa902042e6e807d0595d84c2972d5dd7bd121f0af23d031609" }, (47, 48)),

        new WhitelistEntry("VRCFury - FeatureBuilderActionAttribute",
            new[] { "Editor-Avatars", "Feature", "Base", "FeatureBuilderActionAttribute.cs" },
            new[] { "588bb4675b6ecb0a850bb4f09264df9ef8a5a48db0ef7e97aea5d07a3d9b970e" }, (31, 32)),

        new WhitelistEntry("VRCFury - FeatureFailWhenAddedAttribute",
            new[] { "Editor-Avatars", "Feature", "Base", "FeatureFailWhenAddedAttribute.cs" },
            new[] { "3c39298dd7a4222fd4658181d5891e669722141616789276e690b01936d8a115" }, (14, 15)),

        new WhitelistEntry("VRCFury - FeatureHideTitleInEditorAttribute",
            new[] { "Editor-Avatars", "Feature", "Base", "FeatureHideTitleInEditorAttribute.cs" },
            new[] { "b9cf181afd961be9514a88159426ab81d4e6cbdeaa6ddb20688a79654fe542a8" }, (8, 9)),

        new WhitelistEntry("VRCFury - FeatureOnlyOneAllowedAttribute",
            new[] { "Editor-Avatars", "Feature", "Base", "FeatureOnlyOneAllowedAttribute.cs" },
            new[] { "4bc6b5891bb70d462bb1e3b2fb94c74d28c38317ca83e21b2e83454f74145302" }, (8, 9)),

        new WhitelistEntry("VRCFury - FeatureOrder",
            new[] { "Editor-Avatars", "Feature", "Base", "FeatureOrder.cs" },
            new[] { "48d1bacf1a8aa9b2e14aef8a6b94b14028cd2bc6dfff0f0438be36672c851b12" }, (132, 133)),

        new WhitelistEntry("VRCFury - FeatureRootOnlyAttribute",
            new[] { "Editor-Avatars", "Feature", "Base", "FeatureRootOnlyAttribute.cs" },
            new[] { "9b89a74e89e514a7bb6f64d91118148e9efa7c51934c07933576a9de0080d962" }, (8, 9)),

        new WhitelistEntry("VRCFury - BlendShapeLinkBuilder",
            new[] { "Editor-Avatars", "Feature", "BlendShapeLinkBuilder.cs" },
            new[] { "ac6bbb02848c648d8a1e8884e0b5c10fc6901f530ca4c4aeedf6b49c25540f60" }, (302, 303)),

        new WhitelistEntry("VRCFury - BlendshapeOptimizerBuilder",
            new[] { "Editor-Avatars", "Feature", "BlendshapeOptimizerBuilder.cs" },
            new[] { "48c11eaef42e9885133880dd765a6e333c0921e100e08843136c3dc529aa5d53" }, (260, 261)),

        new WhitelistEntry("VRCFury - BlinkingBuilder",
            new[] { "Editor-Avatars", "Feature", "BlinkingBuilder.cs" },
            new[] { "81742ef24f4225a3845063c8c60d02ffa915e57d574640e1382a5d20488c1270" }, (123, 124)),

        new WhitelistEntry("VRCFury - BoneConstraintBuilder",
            new[] { "Editor-Avatars", "Feature", "BoneConstraintBuilder.cs" },
            new[] { "5e0200bac3f90c37ed65df3611279c57f7b26d577358f80eb563d679b1d38a40" }, (46, 47)),

        new WhitelistEntry("VRCFury - BoundingBoxFixBuilder",
            new[] { "Editor-Avatars", "Feature", "BoundingBoxFixBuilder.cs" },
            new[] { "772fb488abd5c0d7c6a21904a4c087426ec8b2bc55fa9a076a699a8104293c6b" }, (22, 23)),

        new WhitelistEntry("VRCFury - ConstraintRetargetBuilder",
            new[] { "Editor-Avatars", "Feature", "ConstraintRetargetBuilder.cs" },
            new[] { "ba65b088eae86b89b58ef70082b486318f71c1f431b24d9906737cac51c2b973" }, (56, 57)),

        new WhitelistEntry("VRCFury - CrossEyeFixBuilder",
            new[] { "Editor-Avatars", "Feature", "CrossEyeFixBuilder.cs" },
            new[] { "0527b4c8778f019509a476e8ba68525871258a1b4f2a73c61e19df9fc4c9ccd1" }, (67, 68)),

        new WhitelistEntry("VRCFury - DeleteDuringUploadBuilder",
            new[] { "Editor-Avatars", "Feature", "DeleteDuringUploadBuilder.cs" },
            new[] { "36c84d5942a9b7631195c252b1db4b365c09699aab2770ee127b086ba1b84149" }, (20, 21)),

        new WhitelistEntry("VRCFury - DescriptorDebugBuilder",
            new[] { "Editor-Avatars", "Feature", "DescriptorDebugBuilder.cs" },
            new[] { "158d067237a504f18f121add224f63d95db362fd32e6b6b00dc47d930d55b3df" }, (44, 45)),

        new WhitelistEntry("VRCFury - FixWriteDefaultsBuilder",
            new[] { "Editor-Avatars", "Feature", "FixWriteDefaultsBuilder.cs" },
            new[] { "46a282a6a09ac6491fd697aeebc8f3c8e68a1b04bb90dab792e35f5a005c5eb5" }, (77, 78)),

        new WhitelistEntry("VRCFury - FullControllerBuilder",
            new[] { "Editor-Avatars", "Feature", "FullControllerBuilder.cs" },
            new[] { "0f11cb5d3ecdb03ca13b1cd786635c7ebeea410726bb9dd1c99605d588f4e305" }, (712, 713)),

        new WhitelistEntry("VRCFury - GestureDriverBuilder",
            new[] { "Editor-Avatars", "Feature", "GestureDriverBuilder.cs" },
            new[] { "0d118353c1b5142ce28be8a6bdfca6c62cdde61af7d02e4e0c43294da0f0d517" }, (222, 223)),

        new WhitelistEntry("VRCFury - GizmoBuilder",
            new[] { "Editor-Avatars", "Feature", "GizmoBuilder.cs" },
            new[] { "a5017991eebc35505786f5a4f2904576da8276ed2f118fd8010d552fff06bc14" }, (21, 22)),

        new WhitelistEntry("VRCFury - HeadChopHeadBuilder",
            new[] { "Editor-Avatars", "Feature", "HeadChopHeadBuilder.cs" },
            new[] { "62569b59ec711cb4eb1355c75b861040ab6eac09068e6775a2be2703bd1f23eb" }, (46, 47)),

        new WhitelistEntry("VRCFury - LayerToTreeBuilder",
            new[] { "Editor-Avatars", "Feature", "LayerToTreeBuilder.cs" },
            new[] { "3fa8d59aa652d6de85603e477d58ca3b42b579a4c94d9e2ed008a860bf17acad" }, (20, 21)),

        new WhitelistEntry("VRCFury - MmdCompatibilityBuilder",
            new[] { "Editor-Avatars", "Feature", "MmdCompatibilityBuilder.cs" },
            new[] { "7c7073530794a03aa0e04504ab6c5255b8361fb287ced336769c9263bf0edaf1" }, (103, 104)),

        new WhitelistEntry("VRCFury - MoveMenuItemBuilder",
            new[] { "Editor-Avatars", "Feature", "MoveMenuItemBuilder.cs" },
            new[] { "afb0d3b52bd41d63b2f43acd5f753ab2db3db8152c4302c9a9d0f84f39ab2c0a" }, (124, 125)),

        new WhitelistEntry("VRCFury - OGBIntegrationBuilder",
            new[] { "Editor-Avatars", "Feature", "OGBIntegrationBuilder.cs" },
            new[] { "dae29d2f142af35d378fd2dfb635b26a69b9d6fe68e28b1acca8586cac18e3a7" }, (23, 24)),

        new WhitelistEntry("VRCFury - OverrideMenuSettingsBuilder",
            new[] { "Editor-Avatars", "Feature", "OverrideMenuSettingsBuilder.cs" },
            new[] { "1c5b46baef4e5e91006f24ada67c183608f66db2521fd51a9faf0bfbfd05cff5" }, (21, 22)),

        new WhitelistEntry("VRCFury - PuppetBuilder",
            new[] { "Editor-Avatars", "Feature", "PuppetBuilder.cs" },
            new[] { "c62101a4caf28a1727ff829acc99787fb456a82977440b74ae6f77cce41194e5" }, (63, 64)),

        new WhitelistEntry("VRCFury - RemoveBlinkingBuilder",
            new[] { "Editor-Avatars", "Feature", "RemoveBlinkingBuilder.cs" },
            new[] { "42c2208c4cf238375e5485f6c7621eedef84d92f19dfc73bdc8b7f0dd439ad04" }, (28, 29)),

        new WhitelistEntry("VRCFury - RemoveHandGesturesBuilder",
            new[] { "Editor-Avatars", "Feature", "RemoveHandGesturesBuilder.cs" },
            new[] { "d981af7a93720c4e82cb49b74aecb4a3c8aa9972c471f8f76e1185ce54cea27a" }, (46, 47)),

        new WhitelistEntry("VRCFury - ReorderMenuItemBuilder",
            new[] { "Editor-Avatars", "Feature", "ReorderMenuItemBuilder.cs" },
            new[] { "d4e5706c05d75a2377a7dc0ed8a78ce49956499063d7acbe9188640ea1c5b560" }, (34, 35)),

        new WhitelistEntry("VRCFury - SecurityLockBuilder",
            new[] { "Editor-Avatars", "Feature", "SecurityLockBuilder.cs" },
            new[] { "b4437de0616d7067bc771526043634a963e42f07fe3193e17a45167d0348e09b" }, (122, 123)),

        new WhitelistEntry("VRCFury - SecurityRestrictedBuilder",
            new[] { "Editor-Avatars", "Feature", "SecurityRestrictedBuilder.cs" },
            new[] { "19999b3a525ee53ca2f19c19f7c517d18ba21db3eb074bd92dec329c6fa65688" }, (69, 70)),

        new WhitelistEntry("VRCFury - SenkyGestureDriverBuilder",
            new[] { "Editor-Avatars", "Feature", "SenkyGestureDriverBuilder.cs" },
            new[] { "c5873959af5735eb85ff53eb74dcfded9d1d8599985b62fa7b351c770ba78c04" }, (132, 133)),

        new WhitelistEntry("VRCFury - SetIconBuilder",
            new[] { "Editor-Avatars", "Feature", "SetIconBuilder.cs" },
            new[] { "060cc3df2ffb4da2c559cd0d48a2627e4a9b70d4af8dd583a49f1017cbeb52bc" }, (24, 25)),

        new WhitelistEntry("VRCFury - ShowInFirstPersonBuilder",
            new[] { "Editor-Avatars", "Feature", "ShowInFirstPersonBuilder.cs" },
            new[] { "50b3bc58fae4ece50918e2c999035ea74e1b5084bc47370a4a3a8ec7ade8f641" }, (76, 77)),

        new WhitelistEntry("VRCFury - Slot4FixBuilder",
            new[] { "Editor-Avatars", "Feature", "Slot4FixBuilder.cs" },
            new[] { "606fb46fc83f5449fb32d20d8d0010f13ff8ff62b7004ef8bc0088c47a11c1e5" }, (18, 19)),

        new WhitelistEntry("VRCFury - SpsOptionsBuilder",
            new[] { "Editor-Avatars", "Feature", "SpsOptionsBuilder.cs" },
            new[] { "de1ca767bf4ddb5c243084784d80f9369544c5935ea81eb52f2dc2da2b0234ee" }, (33, 34)),

        new WhitelistEntry("VRCFury - TalkingBuilder",
            new[] { "Editor-Avatars", "Feature", "TalkingBuilder.cs" },
            new[] { "b45c9d7198134e3bc71623f5432a50992bcee07798106b01ca8a808427b05950" }, (38, 39)),

        new WhitelistEntry("VRCFury - ToesBuilder",
            new[] { "Editor-Avatars", "Feature", "ToesBuilder.cs" },
            new[] { "417304328e1ae55b355924406766f0e2b6219a6fcf623eaedb1a1b2e34cd55b2" }, (40, 41)),

        new WhitelistEntry("VRCFury - ToggleBuilder",
            new[] { "Editor-Avatars", "Feature", "ToggleBuilder.cs" },
            new[] { "72cb8996561650ad2034e9f6ce0dd0ef1f856d8737ba702d2652a1b8d26abb22" }, (701, 702)),

        new WhitelistEntry("VRCFury - TPSIntegrationBuilder",
            new[] { "Editor-Avatars", "Feature", "TPSIntegrationBuilder.cs" },
            new[] { "59dcb04910bdea7883eedf43a6e164a114b3e251c8b0e5afec90d6cb26a25d78" }, (18, 19)),

        new WhitelistEntry("VRCFury - TpsScaleFixBuilder",
            new[] { "Editor-Avatars", "Feature", "TpsScaleFixBuilder.cs" },
            new[] { "50311ddc6669802fc787edc44340014c6ef098b6f130eec44434fb1fba721171" }, (136, 137)),

        new WhitelistEntry("VRCFury - UnlimitedParametersBuilder",
            new[] { "Editor-Avatars", "Feature", "UnlimitedParametersBuilder.cs" },
            new[] { "9ba3dc1a81913e224f10cc1bbd3a6560748203a75b67664cee02fae251fafee6" }, (25, 26)),

        new WhitelistEntry("VRCFury - VisemesBuilder",
            new[] { "Editor-Avatars", "Feature", "VisemesBuilder.cs" },
            new[] { "61b6c25ce8a79d5af0f7c5c3aa843c7611fe97eed14f637128954a917dc8e644" }, (136, 137)),

        new WhitelistEntry("VRCFury - VRCFuryHapticTouchReceiverBuilder",
            new[] { "Editor-Avatars", "Feature", "VRCFuryHapticTouchReceiverBuilder.cs" },
            new[] { "ca56cb1c95e9839631ef61a766df9fcf57262f3a87b7c794eaf3edfe5c40245d" }, (90, 91)),

        new WhitelistEntry("VRCFury - VRCFuryHapticTouchSenderBuilder",
            new[] { "Editor-Avatars", "Feature", "VRCFuryHapticTouchSenderBuilder.cs" },
            new[] { "003ee4bb60f6e45fcdbdb0e9d7a9f105d3089fb44fd579f062f1eb7f99d343aa" }, (59, 60)),

        new WhitelistEntry("VRCFury - WorldConstraintBuilder",
            new[] { "Editor-Avatars", "Feature", "WorldConstraintBuilder.cs" },
            new[] { "6c5195840a5223e022bf188ab9f1953ea9d914562a312361d5ba80531245701d" }, (16, 17)),

        new WhitelistEntry("VRCFury - ZawooIntegrationBuilder",
            new[] { "Editor-Avatars", "Feature", "ZawooIntegrationBuilder.cs" },
            new[] { "0980daf1ab682887be89cc0b71947d84ea4c3acf08d1caa9c3463d495a27f367" }, (140, 141)),

        new WhitelistEntry("VRCFury - AddComponentHook",
            new[] { "Editor-Avatars", "Hooks", "AddComponentHook.cs" },
            new[] { "fd7ab5c73884bb649fb0a8bae6d3bb9da2bfd7c92bffc0e2aa3ed76befbd9e72" }, (133, 134)),

        new WhitelistEntry("VRCFury - AudioLinkPlayModeRefreshHook",
            new[] { "Editor-Avatars", "Hooks", "AudioLinkFixes", "AudioLinkPlayModeRefreshHook.cs" },
            new[] { "6f0d78c5157d735290dfacc7319e8d003a00116e9c2c69b6c16e12ee040113c9" }, (50, 51)),

        new WhitelistEntry("VRCFury - Av3EmuAnimatorFixHook",
            new[] { "Editor-Avatars", "Hooks", "Av3EmuFixes", "Av3EmuAnimatorFixHook.cs" },
            new[] { "dffc9366ab9ca4d82e2496f3ce9568a113b52cf7b51f38f5aa630a9ec46ac213" }, (121, 122)),

        new WhitelistEntry("VRCFury - Av3EmuSyncTimeFixHook",
            new[] { "Editor-Avatars", "Hooks", "Av3EmuFixes", "Av3EmuSyncTimeFixHook.cs" },
            new[] { "e6627da1b284426d38d6c1db9b8ad36f798c6fc336d403b34d74ebb276f3a5b6" }, (33, 34)),

        new WhitelistEntry("VRCFury - ConstraintUpgradeHook",
            new[] { "Editor-Avatars", "Hooks", "ConstraintUpgradeHook.cs" },
            new[] { "7af5a9c7cbd551c281f2f2a81eb3304ca4f880d11696324f12991e2ee4feedc5" }, (138, 139)),

        new WhitelistEntry("VRCFury - FixGestureManagerBreakingWithNoRig",
            new[] { "Editor-Avatars", "Hooks", "GestureManagerFixes", "FixGestureManagerBreakingWithNoRig.cs" },
            new[] { "b2f178cd51392df768f6a103c128fd99c290868e610deeb0d2c50a7e8fd0eabe" }, (37, 38)),

        new WhitelistEntry("VRCFury - OriginalContactsHook",
            new[] { "Editor-Avatars", "Hooks", "OriginalContactsHook.cs" },
            new[] { "3ddb7c5c7c4c1b2c98dca2abef070fac7d1df4fe120d6079d5b98ab2fdb61c98" }, (99, 100)),

        new WhitelistEntry("VRCFury - OriginalPathsHook",
            new[] { "Editor-Avatars", "Hooks", "OriginalPathsHook.cs" },
            new[] { "ae85176fe9a85a2e75db1796fdd6ab7eeb9a032527dc83ab7e1f792e57cdbead" }, (23, 24)),

        new WhitelistEntry("VRCFury - ParameterCompressorHook",
            new[] { "Editor-Avatars", "Hooks", "ParameterCompressorHook.cs" },
            new[] { "30b25c0132fccbd57c710dffa7048aa906bee3e6d23e5f424917a95064f8ff57" }, (19, 20)),

        new WhitelistEntry("VRCFury - PrefabFixHook",
            new[] { "Editor-Avatars", "Hooks", "PrefabFixHook.cs" },
            new[] { "ab1a9352e78195b2eb02b00bd323a8e0a2c128f3c37374ea5f3c3da526f6364f" }, (85, 86)),

        new WhitelistEntry("VRCFury - PreProcessingFailureCheckHook",
            new[] { "Editor-Avatars", "Hooks", "PreProcessingFailureCheckHook.cs" },
            new[] { "1299548f4b1a71f1468f6fcdac785d6f6d37df7a4503bae5f6076508a9cdeed3" }, (44, 45)),

        new WhitelistEntry("VRCFury - RunPreprocessorsOnlyOncePatch",
            new[] { "Editor-Avatars", "Hooks", "RunPreprocessorsOnlyOncePatch.cs" },
            new[] { "198372de34b826da6cf1fde5b5cca499f8756032d8adc99c534516e61c6a3666" }, (105, 106)),

        new WhitelistEntry("VRCFury - FixAnimatorPreviewBreakingInPlayModeHook",
            new[] { "Editor-Avatars", "Hooks", "UnityFixes", "FixAnimatorPreviewBreakingInPlayModeHook.cs" },
            new[] { "f6d1e47374a96bbafc23c3b0dd2dcf66b80d18a78bd51275425520fa23a0d944" }, (242, 243)),

        new WhitelistEntry("VRCFury - SaneUnitySettingsHook",
            new[] { "Editor-Avatars", "Hooks", "UnityFixes", "SaneUnitySettingsHook.cs" },
            new[] { "0d01d463d475aeab1442b977d53c879fcc0b6df37f215f13156d37e8cf7b4b5c" }, (69, 70)),

        new WhitelistEntry("VRCFury - UnpackWarningHook",
            new[] { "Editor-Avatars", "Hooks", "UnityFixes", "UnpackWarningHook.cs" },
            new[] { "2736b77cdc3c65f00b2e62b4ee78d7b0e5b0e996a5c9b024f5007c0a18ed3c53" }, (54, 55)),

        new WhitelistEntry("VRCFury - VrcfAvatarPreprocessor",
            new[] { "Editor-Avatars", "Hooks", "VrcfAvatarPreprocessor.cs" },
            new[] { "c0612f55b15c79697e9da61bbf7a3f21c5dbfba706bad19ff092ce0077e1f55b" }, (23, 24)),

        new WhitelistEntry("VRCFury - VRCFuryAvatarHook",
            new[] { "Editor-Avatars", "Hooks", "VRCFuryAvatarHook.cs" },
            new[] { "f2529ddf2449587dd092678087c2e7c4d0c7d869e13a80a274ae33ace5d4ec50" }, (157, 158)),

        new WhitelistEntry("VRCFury - VrcPreuploadHook",
            new[] { "Editor-Avatars", "Hooks", "VrcPreuploadHook.cs" },
            new[] { "e321fead79e498ea2dead32a0d17d42d230288d3886465a89b2b15bab04b0707" }, (16, 17)),

        new WhitelistEntry("VRCFury - AllowTooManyParametersHook",
            new[] { "Editor-Avatars", "Hooks", "VrcsdkFixes", "AllowTooManyParametersHook.cs" },
            new[] { "e264bdbfbae9e08db5311713fa267356ee99c2cab4b6d83f059e991bdf5a0b68" }, (40, 41)),

        new WhitelistEntry("VRCFury - DefaultToBuilderTabHook",
            new[] { "Editor-Avatars", "Hooks", "VrcsdkFixes", "DefaultToBuilderTabHook.cs" },
            new[] { "978113b7e2d34196c478c51076e6dde4f775c80c30ae2d4da6f444c30f77439b" }, (43, 44)),

        new WhitelistEntry("VRCFury - DisableColliderUpdateInPlayModeHook",
            new[] { "Editor-Avatars", "Hooks", "VrcsdkFixes", "DisableColliderUpdateInPlayModeHook.cs" },
            new[] { "fa0d45993a6b76c7f4761604449808fe132fad98ddf4949ed3395a4155c59248" }, (34, 35)),

        new WhitelistEntry("VRCFury - FixColliderMirroringHook",
            new[] { "Editor-Avatars", "Hooks", "VrcsdkFixes", "FixColliderMirroringHook.cs" },
            new[] { "d3535be15e2edffa1e3333d77cafcf7b1bf96062329eda861301bd41a85f3bc7" }, (48, 49)),

        new WhitelistEntry("VRCFury - FixContactManagerStopwatchNull",
            new[] { "Editor-Avatars", "Hooks", "VrcsdkFixes", "FixContactManagerStopwatchNull.cs" },
            new[] { "741c00a50ba552ecb01454fa43015df9f98f0c08b532e6ec08c7379c9f6c74d7" }, (40, 41)),

        new WhitelistEntry("VRCFury - FixContactsCrashHook",
            new[] { "Editor-Avatars", "Hooks", "VrcsdkFixes", "FixContactsCrashHook.cs" },
            new[] { "14862eb59c31d85ea4a160d66d4450fc20f94a5e7bc186222fa3ae649470ceb5" }, (49, 50)),

        new WhitelistEntry("VRCFury - FixDupAnimatorWindowHook",
            new[] { "Editor-Avatars", "Hooks", "VrcsdkFixes", "FixDupAnimatorWindowHook.cs" },
            new[] { "cd7af0c1b8860b0337e78e225ce734c00a085e6eda8eba02997a7fd0303b76cf" }, (40, 41)),

        new WhitelistEntry("VRCFury - FixNotPlayingWarningHook",
            new[] { "Editor-Avatars", "Hooks", "VrcsdkFixes", "FixNotPlayingWarningHook.cs" },
            new[] { "929e3307f61cb19a3638c2d331e9b6ee920d2f06f24440e3257ba746184843d8" }, (33, 34)),

        new WhitelistEntry("VRCFury - FixTestUploadThumbnailErrorHook",
            new[] { "Editor-Avatars", "Hooks", "VrcsdkFixes", "FixTestUploadThumbnailErrorHook.cs" },
            new[] { "9ac5c79d443bf515245dd7b03461dbdf8d123a0518c6734a8630688d618b7a11" }, (31, 32)),

        new WhitelistEntry("VRCFury - FixVrcDynamicsNotWorking",
            new[] { "Editor-Avatars", "Hooks", "VrcsdkFixes", "FixVrcDynamicsNotWorking.cs" },
            new[] { "35f2f0a711bf3bf82c6b90b151ec2d27b9b943cb66f7d0a4ba7ee0c2b365cee6" }, (28, 29)),

        new WhitelistEntry("VRCFury - FixVrcsdkValidatorWrongPlatform",
            new[] { "Editor-Avatars", "Hooks", "VrcsdkFixes", "FixVrcsdkValidatorWrongPlatform.cs" },
            new[] { "f865c5cb2963bbb1be887ebd04eb3d47cd3ee0dbe9aa432728071440b69be7c9" }, (36, 37)),

        new WhitelistEntry("VRCFury - KeepEditorOnlyComponentsLongerHook",
            new[] { "Editor-Avatars", "Hooks", "VrcsdkFixes", "KeepEditorOnlyComponentsLongerHook.cs" },
            new[] { "969dcdcc09e6f2ecf87851b73cf97d58d1c05405a9bb584e7a44c987d7dc37a3" }, (54, 55)),

        new WhitelistEntry("VRCFury - PlayModeContactFixHook",
            new[] { "Editor-Avatars", "Hooks", "VrcsdkFixes", "PlayModeContactFixHook.cs" },
            new[] { "f43a065b674fcf5c95516fdbfe8ee0a6375c6ba439760e217949c4ec93e82005" }, (29, 30)),

        new WhitelistEntry("VRCFury - RemoveDeadEditorsHook",
            new[] { "Editor-Avatars", "Hooks", "VrcsdkFixes", "RemoveDeadEditorsHook.cs" },
            new[] { "0126cd2bcb756c3a4eaa993a574d251821e96b0a4a8a58451e955b3cda64b0bf" }, (33, 34)),

        new WhitelistEntry("VRCFury - SuppressBlueprintWarningHook",
            new[] { "Editor-Avatars", "Hooks", "VrcsdkFixes", "SuppressBlueprintWarningHook.cs" },
            new[] { "bf70b66049e4f61fe5589d3feefbe540c6f171851be756d0092d73c8c0f9cac4" }, (36, 37)),

        new WhitelistEntry("VRCFury - WhitelistPatchHook",
            new[] { "Editor-Avatars", "Hooks", "VrcsdkFixes", "WhitelistPatchHook.cs" },
            new[] { "65bb061db57417a1ba7634ada25049b5c800f9404cbe4e8f9755bfb2369a5d4a" }, (87, 88)),

        new WhitelistEntry("VRCFury - WhenBlueprintIdReadyHook",
            new[] { "Editor-Avatars", "Hooks", "WhenBlueprintIdReadyHook.cs" },
            new[] { "9a3ebf9c950225b53786b80cb84b86862e91ed10e2e375c0b79fa49a47b2a243" }, (44, 45)),

        new WhitelistEntry("VRCFury - VRCFuryInjectorTest",
            new[] { "Editor-Avatars", "Injector", "VRCFuryInjectorTest.cs" },
            new[] { "a7bb9b20f629de7604e7dacc83bb347dfe3385b28a03344d8706f7c9778d0272" }, (134, 135)),

        new WhitelistEntry("VRCFury - GuidWrapperPropertyDrawer",
            new[] { "Editor-Avatars", "Inspector", "GuidWrapperPropertyDrawer.cs" },
            new[] { "cc359f90c33396cd5b9ec2de13a68fe73ca3f47af338084aea1751e716b0eab2" }, (80, 81)),

        new WhitelistEntry("VRCFury - PercentSlider2",
            new[] { "Editor-Avatars", "Inspector", "PercentSlider2.cs" },
            new[] { "bf9eb099269f0c34a40c6dbc3f77b404490ac4b203cb61173b677859eaf406f9" }, (52, 53)),

        new WhitelistEntry("VRCFury - PreprocessorsRanEditor",
            new[] { "Editor-Avatars", "Inspector", "PreprocessorsRanEditor.cs" },
            new[] { "b53197c57fb0b9925a919807126ce888cea2d69a0dddff976b4a3061ff604197" }, (48, 49)),

        new WhitelistEntry("VRCFury - VrcfDebugLine",
            new[] { "Editor-Avatars", "Inspector", "VrcfDebugLine.cs" },
            new[] { "598fbc1b9cd4c4e91522c5abc37fa9181e64307d9f9aaf69279fd07516c6673f" }, (111, 112)),

        new WhitelistEntry("VRCFury - VRCFGlobalColliderEditor",
            new[] { "Editor-Avatars", "Inspector", "VRCFGlobalColliderEditor.cs" },
            new[] { "5fb8ca191878a2d5ee3f6063b230c9b1aa804067bd48a9491fd8a2a95fecfcbf" }, (46, 47)),

        new WhitelistEntry("VRCFury - VrcfSearchWindow",
            new[] { "Editor-Avatars", "Inspector", "VrcfSearchWindow.cs" },
            new[] { "91fc855db1d8a5d7225e02e0d057678bb27bb4e77f659e9dec0c9f7a17a62b19" }, (51, 52)),

        new WhitelistEntry("VRCFury - VRCFuryActionDrawer",
            new[] { "Editor-Avatars", "Inspector", "VRCFuryActionDrawer.cs" },
            new[] { "1d90e30908cf728b3b82f7ab111ba34c157ff94cadfb5c5e9ec2d03c46b1beaf" }, (84, 85)),

        new WhitelistEntry("VRCFury - VRCFuryDebugInfoEditor",
            new[] { "Editor-Avatars", "Inspector", "VRCFuryDebugInfoEditor.cs" },
            new[] { "bcb6bf34c98ab2857aab230a17e7fc93e2267485e28d8d1a4db1722a4c182254" }, (24, 25)),

        new WhitelistEntry("VRCFury - AlignMobileParamsMenuItem",
            new[] { "Editor-Avatars", "Menu", "AlignMobileParamsMenuItem.cs" },
            new[] { "801701cdeb94d22f68bf724d9297448243bcfa5cc11772761f54d5ae7a7a367a" }, (35, 36)),

        new WhitelistEntry("VRCFury - AutoUpgradeConstraintsMenuItem",
            new[] { "Editor-Avatars", "Menu", "AutoUpgradeConstraintsMenuItem.cs" },
            new[] { "98b31c874c728e4be365fc1f35a3c8e202f0c0d2c558c81b8f6c6e833526d9d6" }, (34, 35)),

        new WhitelistEntry("VRCFury - AutoUpgradeDpsMenuItem",
            new[] { "Editor-Avatars", "Menu", "AutoUpgradeDpsMenuItem.cs" },
            new[] { "07e469302cf7c0989100dbd2580677b5532959c138f8aa66158e07ce4caa2ff6" }, (33, 34)),

        new WhitelistEntry("VRCFury - BoundingBoxMenuItem",
            new[] { "Editor-Avatars", "Menu", "BoundingBoxMenuItem.cs" },
            new[] { "682968d2eea1e7339fbaf170833664bfaf516d4b3cf6ac1dcef55514176443d3" }, (34, 35)),

        new WhitelistEntry("VRCFury - CompressorMenuItem",
            new[] { "Editor-Avatars", "Menu", "CompressorMenuItem.cs" },
            new[] { "494d69b7962ba509a897e6a924c11af3b2c4eae99de58675ca9ab9d305f51e5e" }, (63, 64)),

        new WhitelistEntry("VRCFury - ConstrainedProportionsMenuItem",
            new[] { "Editor-Avatars", "Menu", "ConstrainedProportionsMenuItem.cs" },
            new[] { "ab8793ec6ad4dc0b52ca9bb8326ce1c354bfad1af70254cc1f8e56c2aaaa0717" }, (102, 103)),

        new WhitelistEntry("VRCFury - DebugCopyMenuItem",
            new[] { "Editor-Avatars", "Menu", "DebugCopyMenuItem.cs" },
            new[] { "868689ac79894a3bcd2e2a413dc87bb416985f7372905460da30ef36ce60774d" }, (34, 35)),

        new WhitelistEntry("VRCFury - DisableDbtOptimizerMenuItem",
            new[] { "Editor-Avatars", "Menu", "DisableDbtOptimizerMenuItem.cs" },
            new[] { "f1a01201faa7ce0fb3eb6f9a0867c06a87fe6f7ea32842bb0ea86b7cfae031dc" }, (35, 36)),

        new WhitelistEntry("VRCFury - DuplicatePhysboneDetector",
            new[] { "Editor-Avatars", "Menu", "DuplicatePhysboneDetector.cs" },
            new[] { "f06424d43bb73201ad28c4a3cfdac0ee11714bfe6c20fd738cdce0d24197c1f3" }, (106, 107)),

        new WhitelistEntry("VRCFury - HapticsToggleMenuItem",
            new[] { "Editor-Avatars", "Menu", "HapticsToggleMenuItem.cs" },
            new[] { "2af6efcfd99b21385d5aaef441c1dbdf81c2c34e8a2ed2206fa7c39612cb3cf8" }, (33, 34)),

        new WhitelistEntry("VRCFury - MenuUtils",
            new[] { "Editor-Avatars", "Menu", "MenuUtils.cs" },
            new[] { "e752cb89f301929e9fa942166a6ef1195cd757da4d1389b981f162c48781f449" }, (15, 16)),

        new WhitelistEntry("VRCFury - RemoveUselessOverridesMenuItem",
            new[] { "Editor-Avatars", "Menu", "RemoveUselessOverridesMenuItem.cs" },
            new[] { "4950503049344d9ec9ef04264e07c5b9fd04dde6e03343f2f80f599085802df1" }, (70, 71)),

        new WhitelistEntry("VRCFury - TestCopyMenuItem",
            new[] { "Editor-Avatars", "Menu", "TestCopyMenuItem.cs" },
            new[] { "c2c441fd4b75a44834e77c4e632324733fb440c2a44daade8f6356c1cab7fc5b" }, (14, 15)),

        new WhitelistEntry("VRCFury - UnpackWarningMenuItem",
            new[] { "Editor-Avatars", "Menu", "UnpackWarningMenuItem.cs" },
            new[] { "cde3be78b38392e0746a5da5401c133b57f8d7398554f30a1b12daa0c1854397" }, (34, 35)),

        new WhitelistEntry("VRCFury - UnusedBoneCleaner",
            new[] { "Editor-Avatars", "Menu", "UnusedBoneCleaner.cs" },
            new[] { "39ce8c952b0a2629ed956c554984f34ec90641211dda3cd11cddc45fc1207aa6" }, (65, 66)),

        new WhitelistEntry("VRCFury - VRCFuryTestCopyMenuItem",
            new[] { "Editor-Avatars", "Menu", "VRCFuryTestCopyMenuItem.cs" },
            new[] { "24524559f8fae627be21aea27db901e6438b41779199be0f4925f585474225e3" }, (44, 45)),

        new WhitelistEntry("VRCFury - ZawooDeleter",
            new[] { "Editor-Avatars", "Menu", "ZawooDeleter.cs" },
            new[] { "ed88c7a09862928b1bc4efc178f43d902e5cdd645edf615d35ee235910ac20ea" }, (93, 94)),

        new WhitelistEntry("VRCFury - FixWriteDefaultsLater",
            new[] { "Editor-Avatars", "PlayMode", "FixWriteDefaultsLater.cs" },
            new[] { "b6e84d3c8c0eedb414a52e0ab4c653d09f8037cbc76a2b676ca8497be5828b26" }, (86, 87)),

        new WhitelistEntry("VRCFury - PlayModeTrigger",
            new[] { "Editor-Avatars", "PlayModeTrigger.cs" },
            new[] { "5398315cf04d0dfe66cb4a206548fb4bb1015217ddf2f6bb5169a7b7eb677277" }, (156, 157)),

        new WhitelistEntry("VRCFury - PreSaveVerifier",
            new[] { "Editor-Avatars", "PreSaveVerifier.cs" },
            new[] { "4b388ba4fb79b66285fe08c5741949023d767ff514145a0a8c32f5b61b5a118b" }, (69, 70)),

        new WhitelistEntry("VRCFury - ActionClipService",
            new[] { "Editor-Avatars", "Service", "ActionClipService.cs" },
            new[] { "7775bffb1b36497ee1f8c73655fdcb2e85b10388fdb4eb6581905ccee03b5554" }, (164, 165)),

        new WhitelistEntry("VRCFury - ActionConflictResolverService",
            new[] { "Editor-Avatars", "Service", "ActionConflictResolverService.cs" },
            new[] { "76979735d996d68a9e7c649262a80fe626a045847c682786de0550bd598a4603" }, (96, 97)),

        new WhitelistEntry("VRCFury - AddDebugParamService",
            new[] { "Editor-Avatars", "Service", "AddDebugParamService.cs" },
            new[] { "77203285a158b2e19079a6b927526d7f57583162f7a1fc979486500ef10b8523" }, (36, 37)),

        new WhitelistEntry("VRCFury - AllClipsService",
            new[] { "Editor-Avatars", "Service", "AllClipsService.cs" },
            new[] { "b8b0fcc4b2deb1a8f61920839a61ad8ee62afc0738011317ade0bf013f447d08" }, (41, 42)),

        new WhitelistEntry("VRCFury - AnimatorHolderService",
            new[] { "Editor-Avatars", "Service", "AnimatorHolderService.cs" },
            new[] { "a051be3e9a174127925add2b46d8e662ffc18c08ada7bbe69411543d0eec69ea" }, (114, 115)),

        new WhitelistEntry("VRCFury - AnimatorLayerControlOffsetService",
            new[] { "Editor-Avatars", "Service", "AnimatorLayerControlOffsetService.cs" },
            new[] { "af6a0231d02eaf0b797ac4c0ce0dc076bee2b26e1b46e76448f7e71f85502a4c" }, (124, 125)),

        new WhitelistEntry("VRCFury - ArmatureLinkService",
            new[] { "Editor-Avatars", "Service", "ArmatureLinkService.cs" },
            new[] { "118cedc628696d76a06be37998ca44ea27dfbf717890bc2924ece76f2fb6376f" }, (551, 552)),

        new WhitelistEntry("VRCFury - AvatarBindingStateService",
            new[] { "Editor-Avatars", "Service", "AvatarBindingStateService.cs" },
            new[] { "2f89f1000eddcb7c1e78adfbaa991ac11f3114af874acf9df78c2e245c932dc7" }, (254, 255)),

        new WhitelistEntry("VRCFury - AvatarColliderService",
            new[] { "Editor-Avatars", "Service", "AvatarColliderService.cs" },
            new[] { "d2b48dc624f889eb5702699232f9fec435acbb111563d058b36ef9413503d7e0" }, (229, 230)),

        new WhitelistEntry("VRCFury - BakeGlobalCollidersService",
            new[] { "Editor-Avatars", "Service", "BakeGlobalCollidersService.cs" },
            new[] { "ac781bd8ae1a7cf85f021894cc8113973d2c848539c2d3ebaac8cf945314967c" }, (24, 25)),

        new WhitelistEntry("VRCFury - BakeHapticPlugsService",
            new[] { "Editor-Avatars", "Service", "BakeHapticPlugsService.cs" },
            new[] { "ed7cc9dd70f209654b57af22a4a552b3c716d4920bbeb384bc8a1e17ae7af7d3" }, (396, 397)),

        new WhitelistEntry("VRCFury - BakeHapticSocketsService",
            new[] { "Editor-Avatars", "Service", "BakeHapticSocketsService.cs" },
            new[] { "1f3d03bef7115927707efc69bfdd9dd233deadfaa78f8ac2fc8d0ed172ce8c0b" }, (451, 452)),

        new WhitelistEntry("VRCFury - BakeHapticVersionsService",
            new[] { "Editor-Avatars", "Service", "BakeHapticVersionsService.cs" },
            new[] { "afd8d5f076049caf2fd03f88d82d5915a2b2b600e2dfcc713ec5ddd4ec0b2747" }, (33, 34)),

        new WhitelistEntry("VRCFury - BoundingBoxFixService",
            new[] { "Editor-Avatars", "Service", "BoundingBoxFixService.cs" },
            new[] { "061468bc7d752f9eafa7ece4f25b90ed1f194991fca5b0069c79ae446bc22386" }, (111, 112)),

        new WhitelistEntry("VRCFury - CleanupEmptyLayersService",
            new[] { "Editor-Avatars", "Service", "CleanupEmptyLayersService.cs" },
            new[] { "7ef5c858840e765d64c3a52acc4aa5d4415926321f8692b6b33750f84584264e" }, (78, 79)),

        new WhitelistEntry("VRCFury - CleanupLegacyService",
            new[] { "Editor-Avatars", "Service", "CleanupLegacyService.cs" },
            new[] { "8a3f624d2d91c67ac13341b7cb4014ac3230b7bf859ca6b2bf68a4362d93980a" }, (30, 31)),

        new WhitelistEntry("VRCFury - ClipBuilderService",
            new[] { "Editor-Avatars", "Service", "ClipBuilderService.cs" },
            new[] { "8a73b539388370d3ebb146fb0501ccdcdbd72eb8766f11a0e4ddd5b821dbd004" }, (53, 54)),

        new WhitelistEntry("VRCFury - ClipFactoryService",
            new[] { "Editor-Avatars", "Service", "ClipFactoryService.cs" },
            new[] { "3e918d61869b4ded7e18767a3f65bc91a70f1ec1a98463b4dd999bc0845cee87" }, (31, 32)),

        new WhitelistEntry("VRCFury - ClipRewritersService",
            new[] { "Editor-Avatars", "Service", "ClipRewritersService.cs" },
            new[] { "913f64821485acdeb282767c84a50678c67280414ceeae4731494d252f766d1f" }, (130, 131)),

        new WhitelistEntry("VRCFury - CloneAllControllersService",
            new[] { "Editor-Avatars", "Service", "CloneAllControllersService.cs" },
            new[] { "323874b1a4ba9cf4bbfbf353a503bff6cdb11c8cd328ada85aac242e27c2ecbb" }, (25, 26)),

        new WhitelistEntry("VRCFury - CompressorLayerUtilsService",
            new[] { "Editor-Avatars", "Service", "Compressor", "CompressorLayerUtilsService.cs" },
            new[] { "06e06e467b1d14a3f005ac70583d8c6058de64f88c25848beda4a5d1d50f3fd1" }, (33, 34)),

        new WhitelistEntry("VRCFury - OptimizationDecision",
            new[] { "Editor-Avatars", "Service", "Compressor", "OptimizationDecision.cs" },
            new[] { "8a6ee4f58ace46e91382dca10078df1fb55051fec448f0e299e57805c40207c5" }, (103, 104)),

        new WhitelistEntry("VRCFury - ParameterCompressorLayerService",
            new[] { "Editor-Avatars", "Service", "Compressor", "ParameterCompressorLayerService.cs" },
            new[] { "dabb7079c42c4df4869d3cd345bcd7f2ddeea3112a8733f84f6149265eaf6a63" }, (150, 151)),

        new WhitelistEntry("VRCFury - ParameterCompressorLegacyLayerService",
            new[] { "Editor-Avatars", "Service", "Compressor", "ParameterCompressorLegacyLayerService.cs" },
            new[] { "e53811be73784407f1a3da503ad4cc8061b8e22e8576d85ceb50ea1ae78a709e" }, (131, 132)),

        new WhitelistEntry("VRCFury - ParameterCompressorService",
            new[] { "Editor-Avatars", "Service", "Compressor", "ParameterCompressorService.cs" },
            new[] { "29a6c34ca05e151cab1ac710ba65e4f95c29c8520e7100572ab0f032568b2f83" }, (125, 126)),

        new WhitelistEntry("VRCFury - ParameterCompressorSolverOutput",
            new[] { "Editor-Avatars", "Service", "Compressor", "ParameterCompressorSolverOutput.cs" },
            new[] { "3bd0195d94c674ecce78781c831a5770e2f4fe2d72901c28ef5ab1c85b7cdd30" }, (35, 36)),

        new WhitelistEntry("VRCFury - ParameterCompressorSolverService",
            new[] { "Editor-Avatars", "Service", "Compressor", "ParameterCompressorSolverService.cs" },
            new[] { "81d6f0b311181ef3711458526a8a5275a257adb8a5e998ec35d8c9f8460cf054" }, (269, 270)),

        new WhitelistEntry("VRCFury - ParameterPlatformAlignmentService",
            new[] { "Editor-Avatars", "Service", "Compressor", "ParameterPlatformAlignmentService.cs" },
            new[] { "f358264ad37294fc1ac2c28d3d0a4dca3766c83584f8f684b792a8f50816d14b" }, (227, 228)),

        new WhitelistEntry("VRCFury - ControllersService",
            new[] { "Editor-Avatars", "Service", "ControllersService.cs" },
            new[] { "b732384aea2d1af29ea1d961abc2ff706e07a40dc5fd40e4a7dd88ab89d3f04c" }, (104, 105)),

        new WhitelistEntry("VRCFury - DbtLayerService",
            new[] { "Editor-Avatars", "Service", "DbtLayerService.cs" },
            new[] { "a075740200231e17d5e89390c7aa018d058f7b3cd32f06dc1ac74505c15dbb0e" }, (26, 27)),

        new WhitelistEntry("VRCFury - DisableSyncForAapsService",
            new[] { "Editor-Avatars", "Service", "DisableSyncForAapsService.cs" },
            new[] { "d21b93b8b023e570fab2c201bc34c60c98c387b4e966264181e34531912c136b" }, (39, 40)),

        new WhitelistEntry("VRCFury - ExceptionService",
            new[] { "Editor-Avatars", "Service", "ExceptionService.cs" },
            new[] { "46639aa21f9395452c129e47fcfe86abf22fd30b21dbee594dd80bb9db17b494" }, (23, 24)),

        new WhitelistEntry("VRCFury - FakeHeadService",
            new[] { "Editor-Avatars", "Service", "FakeHeadService.cs" },
            new[] { "71c71765e409a55727bdf821d2d8cf2f91a77031624a46db20fd3a0ed2937a25" }, (55, 56)),

        new WhitelistEntry("VRCFury - FinalizeControllerService",
            new[] { "Editor-Avatars", "Service", "FinalizeControllerService.cs" },
            new[] { "a6f1c4015815622166e2350de3534333d79a44e16574208fe23675737031b02b" }, (87, 88)),

        new WhitelistEntry("VRCFury - FinalizeMenuService",
            new[] { "Editor-Avatars", "Service", "FinalizeMenuService.cs" },
            new[] { "677c694d47931f8270964102216ffc5d7dc4d20a1243b0cb1ce3c871aed29c1e" }, (57, 58)),

        new WhitelistEntry("VRCFury - FinalValidationService",
            new[] { "Editor-Avatars", "Service", "FinalValidationService.cs" },
            new[] { "bbc424a7f1346b712d9054de7b13de3c993ae6609c7a7035c8bcf3072046c835" }, (61, 62)),

        new WhitelistEntry("VRCFury - FindAnimatedTransformsService",
            new[] { "Editor-Avatars", "Service", "FindAnimatedTransformsService.cs" },
            new[] { "c5152dd6cf3a3bcd4e7e0931b042234c1fc173909f1e8b0eaaa3e410c31e21e0" }, (84, 85)),

        new WhitelistEntry("VRCFury - FixAmbiguousObjectNamesService",
            new[] { "Editor-Avatars", "Service", "FixAmbiguousObjectNamesService.cs" },
            new[] { "bef3a55dd58106151d430882418041046aa9be24d6071dc97b855f30b8537454" }, (48, 49)),

        new WhitelistEntry("VRCFury - FixAnimatedPhysbonesService",
            new[] { "Editor-Avatars", "Service", "FixAnimatedPhysbonesService.cs" },
            new[] { "9ad435e43ba43dde18ceaf5cab70326bc0f34897ef1604db64138545597abe6c" }, (34, 35)),

        new WhitelistEntry("VRCFury - FixAudioService",
            new[] { "Editor-Avatars", "Service", "FixAudioService.cs" },
            new[] { "5eb780a770dc8570f07b7a8f4d2587202229d6e378fe9eebc68134459eabb6c6" }, (70, 71)),

        new WhitelistEntry("VRCFury - FixDoubleFxService",
            new[] { "Editor-Avatars", "Service", "FixDoubleFxService.cs" },
            new[] { "d67050fec69aa6e7e74768370bbff44f414a360a46f8ff030200c3e219115f01" }, (16, 17)),

        new WhitelistEntry("VRCFury - FixEmptyMotionService",
            new[] { "Editor-Avatars", "Service", "FixEmptyMotionService.cs" },
            new[] { "749bcb704d4dcd6e11bd25df74243e5a429f3984e79889f73f6e52ed95025f10" }, (53, 54)),

        new WhitelistEntry("VRCFury - FixMasksService",
            new[] { "Editor-Avatars", "Service", "FixMasksService.cs" },
            new[] { "097f41e204f3c6661ee0ebb98b82b74ea30b30aa023b3de68a6fa0ce9e382f0e" }, (163, 164)),

        new WhitelistEntry("VRCFury - FixMenuIconTexturesService",
            new[] { "Editor-Avatars", "Service", "FixMenuIconTexturesService.cs" },
            new[] { "1795785faf2225abf26800a0aa2294245c73e99a2a4982c01f66945e6f0b79e3" }, (52, 53)),

        new WhitelistEntry("VRCFury - FixMipmapStreamingService",
            new[] { "Editor-Avatars", "Service", "FixMipmapStreamingService.cs" },
            new[] { "e0a62ff350d5560644cd1e14598078aa1bc4e07a2e15d618e9237bd0d61489db" }, (70, 71)),

        new WhitelistEntry("VRCFury - FixPartiallyWeightedAapsService",
            new[] { "Editor-Avatars", "Service", "FixPartiallyWeightedAapsService.cs" },
            new[] { "68cc3acd8bbeeef6762dc672ad1fddd7bf1c60fa9af7f0c6ec0c9268735d882a" }, (63, 64)),

        new WhitelistEntry("VRCFury - FixTreeLengthService",
            new[] { "Editor-Avatars", "Service", "FixTreeLengthService.cs" },
            new[] { "b14b772a768dcd460cc700033f168b4afc169d0addccb332f1886bfa30ea5370" }, (64, 65)),

        new WhitelistEntry("VRCFury - FixWriteDefaultsService",
            new[] { "Editor-Avatars", "Service", "FixWriteDefaultsService.cs" },
            new[] { "369e32748d316d4c31aae7c18e12e7b1e9ccda97be7367062a881c32978bce2d" }, (324, 325)),

        new WhitelistEntry("VRCFury - FloatToDriverService",
            new[] { "Editor-Avatars", "Service", "FloatToDriverService.cs" },
            new[] { "9c62d5fb5ccb0ad0881ce6bcc49d232e76d8268cc1f182ae56227244aeeb7303" }, (78, 79)),

        new WhitelistEntry("VRCFury - ForceStateInAnimatorService",
            new[] { "Editor-Avatars", "Service", "ForceStateInAnimatorService.cs" },
            new[] { "ac1adad21c6bb65ee40e9b50f57278f49d36c4a5b79ca05e6d56ff406f7a6974" }, (32, 33)),

        new WhitelistEntry("VRCFury - FrameTimeService",
            new[] { "Editor-Avatars", "Service", "FrameTimeService.cs" },
            new[] { "f857eb273ce7ba47704b9091675a69bba57510636c0817aba1600ac61096b8d0" }, (57, 58)),

        new WhitelistEntry("VRCFury - FullBodyEmoteService",
            new[] { "Editor-Avatars", "Service", "FullBodyEmoteService.cs" },
            new[] { "ba9052da011056f0f256b51b64365473741c7d218828eea82a3af2576298daad" }, (119, 120)),

        new WhitelistEntry("VRCFury - GlobalsService",
            new[] { "Editor-Avatars", "Service", "GlobalsService.cs" },
            new[] { "f4fc558f3a1ec6379c44fad74040f14bfaef61774885dad8ae0d00b4ee9c1a78" }, (28, 29)),

        new WhitelistEntry("VRCFury - HandGestureDisablingService",
            new[] { "Editor-Avatars", "Service", "HandGestureDisablingService.cs" },
            new[] { "e9043088b2cf03ebf1493fa8475bba1fdd511708c95653b91285d1d311c927c4" }, (63, 64)),

        new WhitelistEntry("VRCFury - HapticAnimContactsService",
            new[] { "Editor-Avatars", "Service", "HapticAnimContactsService.cs" },
            new[] { "861fd02daed476e5073b29a2ca14dd0d9ba81048e42775ec96df9bcc3e0ac718" }, (82, 83)),

        new WhitelistEntry("VRCFury - HapticContactsService",
            new[] { "Editor-Avatars", "Service", "HapticContactsService.cs" },
            new[] { "a3dce11dfc648c6b9902b557dca8d5b75080c678eafd4a2945e928ece5576215" }, (82, 83)),

        new WhitelistEntry("VRCFury - HideAnnoyingGizmosService",
            new[] { "Editor-Avatars", "Service", "HideAnnoyingGizmosService.cs" },
            new[] { "62e46a53ef347b16062fe4ba813c8b956ed3d32e776349a48bfca989c9f925d1" }, (31, 32)),

        new WhitelistEntry("VRCFury - LayerSourceService",
            new[] { "Editor-Avatars", "Service", "LayerSourceService.cs" },
            new[] { "e59e50228812cd8a296c585ffc9c993d574dc10a890864a889782f1f2b339928" }, (47, 48)),

        new WhitelistEntry("VRCFury - LayerToTreeService",
            new[] { "Editor-Avatars", "Service", "LayerToTreeService.cs" },
            new[] { "5b209c259d265a1ebae2f14a789f7468adb72fb459eae02348dd557b95de1b21" }, (328, 329)),

        new WhitelistEntry("VRCFury - MakeAllSyncedDriversLocalService",
            new[] { "Editor-Avatars", "Service", "MakeAllSyncedDriversLocalService.cs" },
            new[] { "a31b0dafbfeab89833a90b8e850a0d53f9728bee0a1ad184f0f612960cd6283b" }, (73, 74)),

        new WhitelistEntry("VRCFury - MakeControllerNamesUniqueService",
            new[] { "Editor-Avatars", "Service", "MakeControllerNamesUniqueService.cs" },
            new[] { "417a0ef8f7072fdc1ad9ec1b81763bc69b4f8a2ab6088d81b971cbd821fe94c2" }, (67, 68)),

        new WhitelistEntry("VRCFury - MarkThingsAsDirtyJustInCaseService",
            new[] { "Editor-Avatars", "Service", "MarkThingsAsDirtyJustInCaseService.cs" },
            new[] { "9821c52c061dc0605242783748a3673ed5f0d6b0d56b19e132c387ca4a2190df" }, (22, 23)),

        new WhitelistEntry("VRCFury - MenuChangesService",
            new[] { "Editor-Avatars", "Service", "MenuChangesService.cs" },
            new[] { "bd83b67e8720064086d49ec4fe447e7362d44b2fa43df41d1f671c3b55933027" }, (50, 51)),

        new WhitelistEntry("VRCFury - MenuService",
            new[] { "Editor-Avatars", "Service", "MenuService.cs" },
            new[] { "6eba7edef78bee5d0bd789e3656c1eafdc1142d12cb261a72470a4f0e8a0c839" }, (35, 36)),

        new WhitelistEntry("VRCFury - NoBadControllerParamsService",
            new[] { "Editor-Avatars", "Service", "NoBadControllerParamsService.cs" },
            new[] { "12fe310dde41de00c455bb25264d92996959b7633162ecce6bd3e27dd76f56d7" }, (34, 35)),

        new WhitelistEntry("VRCFury - NoUnsetPlayableLayersService",
            new[] { "Editor-Avatars", "Service", "NoUnsetPlayableLayersService.cs" },
            new[] { "9ea1642344f87226ac7a52226babdbd2e188581988a34e9ff7d6f53007282d20" }, (28, 29)),

        new WhitelistEntry("VRCFury - ObjectMoveService",
            new[] { "Editor-Avatars", "Service", "ObjectMoveService.cs" },
            new[] { "07506c5f3f9cf3de7f1e0b6918d9b32b0994b1d9c7e9ea981db6d945e9b8a5d4" }, (73, 74)),

        new WhitelistEntry("VRCFury - OriginalAvatarService",
            new[] { "Editor-Avatars", "Service", "OriginalAvatarService.cs" },
            new[] { "ef5ad23eea9c14f1d14bc33bef99d8b57f94463a191b7f99b7e134d082d03fdf" }, (43, 44)),

        new WhitelistEntry("VRCFury - OverlappingContactsFixService",
            new[] { "Editor-Avatars", "Service", "OverlappingContactsFixService.cs" },
            new[] { "dd32f35490add188081176b91c68f7f6e3ff240b164ff18de11e72659348a506" }, (58, 59)),

        new WhitelistEntry("VRCFury - ParameterSourceService",
            new[] { "Editor-Avatars", "Service", "ParameterSourceService.cs" },
            new[] { "89dd578d7b915d8518ae9f4700b028caffaff6ed13da75a398693672320ab5f9" }, (37, 38)),

        new WhitelistEntry("VRCFury - ParamsService",
            new[] { "Editor-Avatars", "Service", "ParamsService.cs" },
            new[] { "d7fea4e91252c8c69cd5880af5a60519e5c4e5071379b7e48e0a849858171601" }, (50, 51)),

        new WhitelistEntry("VRCFury - ParticleSystemFixService",
            new[] { "Editor-Avatars", "Service", "ParticleSystemFixService.cs" },
            new[] { "088bb367657173162576b404c7531869a8ab5f96f171f71bf0d42eca3ce73f3d" }, (34, 35)),

        new WhitelistEntry("VRCFury - PhysboneResetService",
            new[] { "Editor-Avatars", "Service", "PhysboneResetService.cs" },
            new[] { "f976bfa4d48f950d96223204c1a3d678b28ba84b80ca72aadf7343665eb92d16" }, (36, 37)),

        new WhitelistEntry("VRCFury - RemoveDefaultControllersService",
            new[] { "Editor-Avatars", "Service", "RemoveDefaultControllersService.cs" },
            new[] { "300bc81905bd7ce49c26b0c35d562d1889b066fe26687a56d45b834782419476" }, (49, 50)),

        new WhitelistEntry("VRCFury - RemoveExtraDescriptorsService",
            new[] { "Editor-Avatars", "Service", "RemoveExtraDescriptorsService.cs" },
            new[] { "3225b9527b20aa98586a4e54f054760b180bf68a8e757bd27914bb60eeaae5cb" }, (29, 30)),

        new WhitelistEntry("VRCFury - RemoveNonQuestMaterialsService",
            new[] { "Editor-Avatars", "Service", "RemoveNonQuestMaterialsService.cs" },
            new[] { "523a660925548aa56374046ec21905dd33207c359ebed0e62370cbe4c62801b7" }, (74, 75)),

        new WhitelistEntry("VRCFury - RemoveVrcGlobalsFromExpressionParamsService",
            new[] { "Editor-Avatars", "Service", "RemoveVrcGlobalsFromExpressionParamsService.cs" },
            new[] { "66a58e215bc3a8a3b0a0579088c3dd55961c99f00440a866f55be548350329f2" }, (24, 25)),

        new WhitelistEntry("VRCFury - RestingStateService",
            new[] { "Editor-Avatars", "Service", "RestingStateService.cs" },
            new[] { "890e5c5052bbf4f3e9c26209ba9308e5eb44ec927c63a211d4a5e9573cebed49" }, (124, 125)),

        new WhitelistEntry("VRCFury - SaveAssetsService",
            new[] { "Editor-Avatars", "Service", "SaveAssetsService.cs" },
            new[] { "9a0369f2bc681fb038e9156cc54f98cc25b36c3fe6bc67c017022d7d9cc751d5" }, (53, 54)),

        new WhitelistEntry("VRCFury - SaveDebugCopiesService",
            new[] { "Editor-Avatars", "Service", "SaveDebugCopiesService.cs" },
            new[] { "b66038f99a8770b877558bfa90f9dd455f158428a1e7d47434a84ad4044cc750" }, (40, 41)),

        new WhitelistEntry("VRCFury - ScaleFactorService",
            new[] { "Editor-Avatars", "Service", "ScaleFactorService.cs" },
            new[] { "e75b4865fa397ac818d9e8080fd32decb45e28e132b5c75cf00aaa07c1420aac" }, (69, 70)),

        new WhitelistEntry("VRCFury - ScalePropertyCompensationService",
            new[] { "Editor-Avatars", "Service", "ScalePropertyCompensationService.cs" },
            new[] { "740ef7b73c90517adccd7f0be6a52cb34f45da3da82b2e9dd40c19b2d6c9b6f0" }, (50, 51)),

        new WhitelistEntry("VRCFury - SmoothingService",
            new[] { "Editor-Avatars", "Service", "SmoothingService.cs" },
            new[] { "04d1d5355213fa3516dc81f33bea1eb69edfa0ca76986a271d6ca67931dd8178" }, (85, 86)),

        new WhitelistEntry("VRCFury - SpsOptionsService",
            new[] { "Editor-Avatars", "Service", "SpsOptionsService.cs" },
            new[] { "3808f8c85686b18c33a394cf182f823016daed966e66c055f3d9d938775e5d07" }, (75, 76)),

        new WhitelistEntry("VRCFury - SpsSendersForAllService",
            new[] { "Editor-Avatars", "Service", "SpsSendersForAllService.cs" },
            new[] { "1adc1d431f825ee469953a5989e2e70c8203047d03a516ea1811cd38b9656cfc" }, (48, 49)),

        new WhitelistEntry("VRCFury - TmpDirService",
            new[] { "Editor-Avatars", "Service", "TmpDirService.cs" },
            new[] { "ca6a413e9fb31d008a84ef4addba528b9b80055d014be3e5576b89eb437daa11" }, (45, 46)),

        new WhitelistEntry("VRCFury - TrackingConflictResolverService",
            new[] { "Editor-Avatars", "Service", "TrackingConflictResolverService.cs" },
            new[] { "c13cf1086024a2de17eb6944a1363c59d1461abdc1a11125f9050b32016d642c" }, (226, 227)),

        new WhitelistEntry("VRCFury - TreeFlatteningService",
            new[] { "Editor-Avatars", "Service", "TreeFlatteningService.cs" },
            new[] { "5c783125135ce697975f82ef2085357cea0fa45f82b72c0a45ea5d615ae7bef8" }, (158, 159)),

        new WhitelistEntry("VRCFury - UpgradeToVrcConstraintsService",
            new[] { "Editor-Avatars", "Service", "UpgradeToVrcConstraintsService.cs" },
            new[] { "78026f037a6ee594b57b418b89c1a935408ee0efa02d583d2217878bfa19d65e" }, (91, 92)),

        new WhitelistEntry("VRCFury - ValidateBindingsService",
            new[] { "Editor-Avatars", "Service", "ValidateBindingsService.cs" },
            new[] { "9c41ed3583a1418deef91ede556efe4d13c277c47667a131b80d0d70c6d6f744" }, (61, 62)),

        new WhitelistEntry("VRCFury - WorldDropService",
            new[] { "Editor-Avatars", "Service", "WorldDropService.cs" },
            new[] { "ed6e7bf3e19ff6bf8a20e6784300082ed54a76871be07d46d0980f636a37d37b" }, (95, 96)),

        new WhitelistEntry("VRCFury - UpdateMenuItem",
            new[] { "Editor-Avatars", "Updater", "UpdateMenuItem.cs" },
            new[] { "78d89c2834181fac4439e51558a674427df05e62daa29ccbb47b7e59ff90484f" }, (69, 70)),

        new WhitelistEntry("VRCFury - AnimationClipAvatarExtensions",
            new[] { "Editor-Avatars", "Utils", "AnimationClipAvatarExtensions.cs" },
            new[] { "b709d805fdd2de4dbbde43e2111177a02e2c15224dcae8c4b594d078cdab237d" }, (36, 37)),

        new WhitelistEntry("VRCFury - AvatarCleaner",
            new[] { "Editor-Avatars", "Utils", "AvatarCleaner.cs" },
            new[] { "096685ca237831c0493eaaddfb7adac6c947926a1d5f8f94a132f9588272eb6d" }, (227, 228)),

        new WhitelistEntry("VRCFury - BlendtreeMath",
            new[] { "Editor-Avatars", "Utils", "BlendtreeMath.cs" },
            new[] { "fa37810bb0dcafdc8e3552af52a0dcf9d424dc8e305d0df7d4200f15461e3a87" }, (440, 441)),

        new WhitelistEntry("VRCFury - ClosestBoneUtils",
            new[] { "Editor-Avatars", "Utils", "ClosestBoneUtils.cs" },
            new[] { "0ff8f1bd08c571b4d5714e12e428f4083d59d74a488fa3a6ffdfdcbcef7c518b" }, (100, 101)),

        new WhitelistEntry("VRCFury - CollapseUtils",
            new[] { "Editor-Avatars", "Utils", "CollapseUtils.cs" },
            new[] { "5afbb184f1c104c6f2fcb832a673562f1a5308bc7744a27d0a8e7e9ebc2d6d3f" }, (57, 58)),

        new WhitelistEntry("VRCFury - ControllerManager",
            new[] { "Editor-Avatars", "Utils", "ControllerManager.cs" },
            new[] { "353da51c8c86b1d9193b48026a528498c7e50b1002c3763ad3a7468d9f132a0c" }, (179, 180)),

        new WhitelistEntry("VRCFury - DictionaryExtensions",
            new[] { "Editor-Avatars", "Utils", "DictionaryExtensions.cs" },
            new[] { "5955933e95d74e74807e7f61cbb686ebb3e07bc04ece9fa29cd12624799bd0c7" }, (11, 12)),

        new WhitelistEntry("VRCFury - MenuEstimator",
            new[] { "Editor-Avatars", "Utils", "MenuEstimator.cs" },
            new[] { "cd587e3804969b5303abcdd0b9a59c529095fb5c963c3a8a0154dfb05bf5e335" }, (46, 47)),

        new WhitelistEntry("VRCFury - MenuManager",
            new[] { "Editor-Avatars", "Utils", "MenuManager.cs" },
            new[] { "2e18dc3c60d562f38f9e2ac2c2f5cea3968003cec4078aff05475f5ca3c47806" }, (343, 344)),

        new WhitelistEntry("VRCFury - ParamManager",
            new[] { "Editor-Avatars", "Utils", "ParamManager.cs" },
            new[] { "dcf6eee23ab1cdca5d2d1cf2c1a3f446887d9da1246cd2a7437977221666a17b" }, (25, 26)),

        new WhitelistEntry("VRCFury - RecorderUtils",
            new[] { "Editor-Avatars", "Utils", "RecorderUtils.cs" },
            new[] { "e80bfde5998879795fe72b75dae34c572f75df709cb101b955f8d96831295753" }, (174, 175)),

        new WhitelistEntry("VRCFury - ShaderExtensions",
            new[] { "Editor-Avatars", "Utils", "ShaderExtensions.cs" },
            new[] { "6c92521abb0e0360f49276bb118df969186cb7d6c56c0c10f44b8980823ce834" }, (16, 17)),

        new WhitelistEntry("VRCFury - Vector2Extensions",
            new[] { "Editor-Avatars", "Utils", "Vector2Extensions.cs" },
            new[] { "16176f5a6c49cf38029fd287c871da3153ee0d256472bb780c5ff18ff6a2d305" }, (16, 17)),

        new WhitelistEntry("VRCFury - VFControllerAvatarExtensions",
            new[] { "Editor-Avatars", "Utils", "VFControllerAvatarExtensions.cs" },
            new[] { "66841eef08856dcdb85773432d8bf15b881d676620dc83962cb3aa6a83408f12" }, (63, 64)),

        new WhitelistEntry("VRCFury - VFControllerWithVrcType",
            new[] { "Editor-Avatars", "Utils", "VFControllerWithVrcType.cs" },
            new[] { "4f1728a80a10644f9abbd8230cb0e457ac7fc787769b9b2d11c5b17835bb072e" }, (77, 78)),

        new WhitelistEntry("VRCFury - VFLazyCache",
            new[] { "Editor-Avatars", "Utils", "VFLazyCache.cs" },
            new[] { "ec06a797369ae13f63fe879609e6886c402a943468404a31615b2866c5505c8a" }, (17, 18)),

        new WhitelistEntry("VRCFury - VFStateAvatarExtensions",
            new[] { "Editor-Avatars", "Utils", "VFStateAvatarExtensions.cs" },
            new[] { "36a9b29d57f11463bbf2ddbdca6fb256a18da9b3c9c54257df7852b2df1c7eb2" }, (76, 77)),

        new WhitelistEntry("VRCFury - VRCAvatarDescriptorExtensions",
            new[] { "Editor-Avatars", "Utils", "VRCAvatarDescriptorExtensions.cs" },
            new[] { "638fe4d5c29255d3d99ba58d95d885697ece707524c4a92ea22db026353f4bfc" }, (98, 99)),

        new WhitelistEntry("VRCFury - VRCExpressionParameterExtensions",
            new[] { "Editor-Avatars", "Utils", "VRCExpressionParameterExtensions.cs" },
            new[] { "e4f35fa01ed9c84f94e57d0ec4478cd410aac1243868e8398cd5a37ed3eea721" }, (46, 47)),

        new WhitelistEntry("VRCFury - VRCExpressionParametersExtensions",
            new[] { "Editor-Avatars", "Utils", "VRCExpressionParametersExtensions.cs" },
            new[] { "cc1213c910d4499219f8e1b829dd4fa51838de67773da35c58ab7d3c69da492a" }, (60, 61)),

        new WhitelistEntry("VRCFury - VRCExpressionsMenuExtensions",
            new[] { "Editor-Avatars", "Utils", "VRCExpressionsMenuExtensions.cs" },
            new[] { "b7a6c946a0aa5d6a8f6f345f75ecb17bf0bcf078ace2c23bee99d1219c03e7c0" }, (74, 75)),

        new WhitelistEntry("VRCFury - VrcfAnimationDebugInfo",
            new[] { "Editor-Avatars", "Utils", "VrcfAnimationDebugInfo.cs" },
            new[] { "065b44db45fbb2bdc999284e2f14946a758eddea58302a149f55e64e5fc0e0db" }, (241, 242)),

        new WhitelistEntry("VRCFury - VRCFPackageUtils",
            new[] { "Editor-Avatars", "VRCFPackageUtils.cs" },
            new[] { "4bd32dd0fe6547c445c720a126a0095de314a47c05e67f14695078bac2ed7cdb" }, (53, 54)),

        new WhitelistEntry("VRCFury - VRCFProgressWindow",
            new[] { "Editor-Avatars", "VRCFProgressWindow.cs" },
            new[] { "f22ae955277ca36294019dcafc744100367a42e4513d223966112bf657d9499b" }, (79, 80)),

        new WhitelistEntry("VRCFury - _InternalsVisibleTo",
            new[] { "Editor-Common", "_InternalsVisibleTo.cs" },
            new[] { "ec79b419a048ac8e04f2e633c7d04fe8c15dafd4a653abe1eb5402109f504e2e" }, (5, 6)),

        new WhitelistEntry("VRCFury - ActionBuilder",
            new[] { "Editor-Common", "Actions", "ActionBuilder.cs" },
            new[] { "580d3caa3bce3e9081ecb57355b19c909452615802a6cc8338af779a340ca372" }, (15, 16)),

        new WhitelistEntry("VRCFury - DpsConfigurer",
            new[] { "Editor-Common", "Builder", "Haptics", "DpsConfigurer.cs" },
            new[] { "15af6e97cd02ada83efdff89499b585acd3664910d93caaf944f1175fe31f96c" }, (17, 18)),

        new WhitelistEntry("VRCFury - HapticSenderFactory",
            new[] { "Editor-Common", "Builder", "Haptics", "HapticSenderFactory.cs" },
            new[] { "12c7cc0af7656ae92c631d62b5cb749094fd472a12d215c14e2e1608faa732c2" }, (57, 58)),

        new WhitelistEntry("VRCFury - HapticUtils",
            new[] { "Editor-Common", "Builder", "Haptics", "HapticUtils.cs" },
            new[] { "c5cefbe2a52016b44021bd040251cad6551bd32d187195ee8689e13eae69ee52" }, (206, 207)),

        new WhitelistEntry("VRCFury - PlugMaskGenerator",
            new[] { "Editor-Common", "Builder", "Haptics", "PlugMaskGenerator.cs" },
            new[] { "ffc2ac82b28235617939c34652d09589f7edeaa5a9906d137f336938c7b9f1d7" }, (86, 87)),

        new WhitelistEntry("VRCFury - PlugRendererFinder",
            new[] { "Editor-Common", "Builder", "Haptics", "PlugRendererFinder.cs" },
            new[] { "4f478216fe5c73df7e1296e60f97bc0bb8ec1bda64d325343deb9ccc0512f363" }, (89, 90)),

        new WhitelistEntry("VRCFury - PlugSizeDetector",
            new[] { "Editor-Common", "Builder", "Haptics", "PlugSizeDetector.cs" },
            new[] { "13efafa81a3b003f167696156d4e5453b1d9609f6ae5cb1c5234a49e34e5952d" }, (174, 175)),

        new WhitelistEntry("VRCFury - SpsAutoRigger",
            new[] { "Editor-Common", "Builder", "Haptics", "SpsAutoRigger.cs" },
            new[] { "bab12ef6436d9cbd3571b15182d4621f09d35fe9ab4952ed3fbf0469fc18cf8e" }, (91, 92)),

        new WhitelistEntry("VRCFury - SpsBakedTexture",
            new[] { "Editor-Common", "Builder", "Haptics", "SpsBakedTexture.cs" },
            new[] { "c22b82e5c6a54ce8ab7009d53d8edfb2b58068b8fd54d73b2d3e4aaa0b49e97b" }, (43, 44)),

        new WhitelistEntry("VRCFury - SpsBaker",
            new[] { "Editor-Common", "Builder", "Haptics", "SpsBaker.cs" },
            new[] { "a92e4b0c65de7cabe66b2b23b5a12ad6ae3ed69949c90dc3e8f007c30be52575" }, (66, 67)),

        new WhitelistEntry("VRCFury - SpsConfigurer",
            new[] { "Editor-Common", "Builder", "Haptics", "SpsConfigurer.cs" },
            new[] { "453dc789eba65e46e80a29a9cea98a743b0aea872220682c70e81b4551db3d58" }, (65, 66)),

        new WhitelistEntry("VRCFury - SpsErrorMatException",
            new[] { "Editor-Common", "Builder", "Haptics", "SpsErrorMatException.cs" },
            new[] { "53fd0365e748a6a8e536dc9ff1df08b8e5de7578921784e61e127b47263cce54" }, (11, 12)),

        new WhitelistEntry("VRCFury - SpsPatcher",
            new[] { "Editor-Common", "Builder", "Haptics", "SpsPatcher.cs" },
            new[] { "8e058176ee7c601638a35c52d019769deabee6c422fecf867814ff50fcc80797" }, (780, 781)),

        new WhitelistEntry("VRCFury - TpsConfigurer",
            new[] { "Editor-Common", "Builder", "Haptics", "TpsConfigurer.cs" },
            new[] { "45e061e17e851c7e05b601f0ffa12cffc10732f4bcc28ab12ef78758d802820d" }, (153, 154)),

        new WhitelistEntry("VRCFury - MeshBaker",
            new[] { "Editor-Common", "Builder", "MeshBaker.cs" },
            new[] { "3d814347d4b6220030c745da61f5931407247ac262be1b8ad1101ab5250298cf" }, (70, 71)),

        new WhitelistEntry("VRCFury - VRCFPrefabFixer",
            new[] { "Editor-Common", "Builder", "VRCFPrefabFixer.cs" },
            new[] { "c2ef9a102745da0f62dac4366df158b5c9fa28d0ef443edbfe4482df25cca2c9" }, (107, 108)),

        new WhitelistEntry("VRCFury - ExceptionWithCause",
            new[] { "Editor-Common", "Exceptions", "ExceptionWithCause.cs" },
            new[] { "f6d93e7e79c073f6ca82937ef1e021e0e40694f0baf2ba8e5a8778897f7e8202" }, (8, 9)),

        new WhitelistEntry("VRCFury - SneakyException",
            new[] { "Editor-Common", "Exceptions", "SneakyException.cs" },
            new[] { "1ed69fa3ea0223591dbb54cbea882780dba87ccc18aa813567849406800b367e" }, (22, 23)),

        new WhitelistEntry("VRCFury - VRCFBuilderException",
            new[] { "Editor-Common", "Exceptions", "VRCFBuilderException.cs" },
            new[] { "7d3e672e51642dfd9b705e489ec4fb2aca27337e858c03fcacddf24913d68ad7" }, (8, 9)),

        new WhitelistEntry("VRCFury - VRCFExceptionUtils",
            new[] { "Editor-Common", "Exceptions", "VRCFExceptionUtils.cs" },
            new[] { "089137fe611242bd095e8b65e335fba480e1558fc6015d2f5f52547927448287" }, (91, 92)),

        new WhitelistEntry("VRCFury - FeatureAliasAttribute",
            new[] { "Editor-Common", "Feature", "Base", "FeatureAliasAttribute.cs" },
            new[] { "8968eacb6930028064e75936eba8bf63116fd7931e76892f7cb01d6463df6894" }, (14, 15)),

        new WhitelistEntry("VRCFury - FeatureBuilder",
            new[] { "Editor-Common", "Feature", "Base", "FeatureBuilder.cs" },
            new[] { "0a8b2a8c17952928b7ceb4f10ab2906823a0fbecf296c9806b5bd99a24cd03d2" }, (17, 18)),

        new WhitelistEntry("VRCFury - FeatureEditorAttribute",
            new[] { "Editor-Common", "Feature", "Base", "FeatureEditorAttribute.cs" },
            new[] { "59072efe3286cae75411ab9290bef18439661b4e50558a9c42baea3f1ced06fc" }, (9, 10)),

        new WhitelistEntry("VRCFury - FeatureFinder",
            new[] { "Editor-Common", "Feature", "Base", "FeatureFinder.cs" },
            new[] { "8b6bc924880895046159c66e93dc0f019f04a9be63b1059b3b593904f6e2561d" }, (159, 160)),

        new WhitelistEntry("VRCFury - FeatureHideInMenuAttribute",
            new[] { "Editor-Common", "Feature", "Base", "FeatureHideInMenuAttribute.cs" },
            new[] { "28164385e793950501fbe8e3be1eea2bf830ed07db47c0972cfe87c61a64dd19" }, (8, 9)),

        new WhitelistEntry("VRCFury - FeatureTitleAttribute",
            new[] { "Editor-Common", "Feature", "Base", "FeatureTitleAttribute.cs" },
            new[] { "12051a0d2f42169001deecb4d78055440eb38ac685bc46f7dee37792b0a44d90" }, (14, 15)),

        new WhitelistEntry("VRCFury - IVRCFuryBuilder",
            new[] { "Editor-Common", "Feature", "Base", "IVRCFuryBuilder.cs" },
            new[] { "d1a53239b1518408fb23b7e903a5915c64f7e348ec5aebc1e5b0a56f3c8e44ba" }, (7, 8)),

        new WhitelistEntry("VRCFury - RenderFeatureEditorException",
            new[] { "Editor-Common", "Feature", "Base", "RenderFeatureEditorException.cs" },
            new[] { "9aada8eb71c079aada3b8ff3c4ceb429c0672f6a490d32a95d4583409bff1b05" }, (8, 9)),

        new WhitelistEntry("VRCFury - GuidWrapperExtensions",
            new[] { "Editor-Common", "GuidWrapperExtensions.cs" },
            new[] { "39e5ff4bb7a2194f60e4eeecc8d6d49aabe35029ca4511c82dfe01d95fa5d637" }, (56, 57)),

        new WhitelistEntry("VRCFury - DisablePluginsWhenNotUploadingHook",
            new[] { "Editor-Common", "Hooks", "DisablePluginsWhenNotUploadingHook.cs" },
            new[] { "ae248dfa9be08e1005ded4f9665f3f7be214920f59866d294af1767f58646417" }, (66, 67)),

        new WhitelistEntry("VRCFury - IsActuallyUploadingHook",
            new[] { "Editor-Common", "Hooks", "IsActuallyUploadingHook.cs" },
            new[] { "25b75f1e327975bca9bc7b7fb2dd2d23ecb892bd597ec0d770828aea5f3c21d0" }, (32, 33)),

        new WhitelistEntry("VRCFury - PreventComponentDeletionHook",
            new[] { "Editor-Common", "Hooks", "PreventComponentDeletionHook.cs" },
            new[] { "77af77c33786743c2c2e116b4f514be9a8d24c9dfc3f5a6574ea830bc34a3d7c" }, (64, 65)),

        new WhitelistEntry("VRCFury - DisableAutoSaveHook",
            new[] { "Editor-Common", "Hooks", "UnityFixes", "DisableAutoSaveHook.cs" },
            new[] { "b3193881c728b2d0b2e2237e443f2d56065c13baf428d8bbd1573e30b320180c" }, (29, 30)),

        new WhitelistEntry("VRCFury - DoNotImportBadPackagesHook",
            new[] { "Editor-Common", "Hooks", "UnityFixes", "DoNotImportBadPackagesHook.cs" },
            new[] { "3d2d0cf4cf4fd3bd1b2636bcdeb7d39878a585e2a2c428a90ff352dff3300817" }, (184, 185)),

        new WhitelistEntry("VRCFury - FixAnimatorLayerScrollHook",
            new[] { "Editor-Common", "Hooks", "UnityFixes", "FixAnimatorLayerScrollHook.cs" },
            new[] { "e6b4d14772c6369e17e4f4b39738e85944b89f7fa82b0f598b48d1cadabe9f86" }, (51, 52)),

        new WhitelistEntry("VRCFury - FixUnityWakeUpExceptionHook",
            new[] { "Editor-Common", "Hooks", "UnityFixes", "FixUnityWakeUpExceptionHook.cs" },
            new[] { "a8b668e5bbaa0c995901432f5e9dbba1150a3de8b31f1f16d33ba6e1cb3a6352" }, (51, 52)),

        new WhitelistEntry("VRCFury - InputFieldOnValidateDuringRefreshHook",
            new[] { "Editor-Common", "Hooks", "UnityFixes", "InputFieldOnValidateDuringRefreshHook.cs" },
            new[] { "63b357823a4514fcbc711ea1f3b2e34a1fad885c943141824d10d005f5e80a3e" }, (35, 36)),

        new WhitelistEntry("VRCFury - PreventStateDragInLiveLinkHook",
            new[] { "Editor-Common", "Hooks", "UnityFixes", "PreventStateDragInLiveLinkHook.cs" },
            new[] { "e94fb3e0f202d484e692736178f72dbdf2bcc0cb2e45a2ed52a7e91b12ef8061" }, (46, 47)),

        new WhitelistEntry("VRCFury - SetPlayModeSettingsHook",
            new[] { "Editor-Common", "Hooks", "UnityFixes", "SetPlayModeSettingsHook.cs" },
            new[] { "e3adc066d3d79a539fbdce782e5590744ee53918d2cc415ac0755cae92de1350" }, (34, 35)),

        new WhitelistEntry("VRCFury - VFInitHook",
            new[] { "Editor-Common", "Hooks", "VFInitHook.cs" },
            new[] { "72a7f8996c7472edd46de4c400484078392f2cec0c98ed605f9757d79076b09a" }, (60, 61)),

        new WhitelistEntry("VRCFury - DisableVpmResolverAutoInitHook",
            new[] { "Editor-Common", "Hooks", "VrcsdkFixes", "DisableVpmResolverAutoInitHook.cs" },
            new[] { "f24bc101356e66c7fceee3336b8fe87e44ede0a20ca0cba18da323e37e92be38" }, (36, 37)),

        new WhitelistEntry("VRCFury - FixVrcsdkNonenglishLocaleCrashHook",
            new[] { "Editor-Common", "Hooks", "VrcsdkFixes", "FixVrcsdkNonenglishLocaleCrashHook.cs" },
            new[] { "662112c1888d48190e2a5c4dcffb55b71633696f1560064576603376ef5169cf" }, (46, 47)),

        new WhitelistEntry("VRCFury - FixVrcsdkSavingEverythingOnDomainReloadHook",
            new[] { "Editor-Common", "Hooks", "VrcsdkFixes", "FixVrcsdkSavingEverythingOnDomainReloadHook.cs" },
            new[] { "d6f7183e91947b33ca2f667e57dc4471b2ff6b558d204cd301d341d70e624b7c" }, (40, 41)),

        new WhitelistEntry("VRCFury - HideXrSettingsHook",
            new[] { "Editor-Common", "Hooks", "VrcsdkFixes", "HideXrSettingsHook.cs" },
            new[] { "ae45e093418e4e09704005f4f06a7f1e7f7bbb0d04dbd8037a02646aa9674786" }, (39, 40)),

        new WhitelistEntry("VRCFury - SuppressAmplitudeErrorsHook",
            new[] { "Editor-Common", "Hooks", "VrcsdkFixes", "SuppressAmplitudeErrorsHook.cs" },
            new[] { "10b4c790724a2e022463a4a6616da2cbdb6f99462aacded5d99445c8072c0c9b" }, (33, 34)),

        new WhitelistEntry("VRCFury - VFAutowiredAttribute",
            new[] { "Editor-Common", "Injector", "VFAutowiredAttribute.cs" },
            new[] { "fdbea1d483942023f37e8da792564735c4b9693ca41425d0ab523679268f7a21" }, (10, 11)),

        new WhitelistEntry("VRCFury - VFInjectorParent",
            new[] { "Editor-Common", "Injector", "VFInjectorParent.cs" },
            new[] { "487f943c9bdde1815cc1bf904d3f3a18b46817a2f6e8de1fee99f4d9abfada58" }, (5, 6)),

        new WhitelistEntry("VRCFury - VFPrototypeScopeAttribute",
            new[] { "Editor-Common", "Injector", "VFPrototypeScopeAttribute.cs" },
            new[] { "5418d4d39c222a8f5a721d6429d899817753a99cf81ae2ee01768f9d5637d3e6" }, (8, 9)),

        new WhitelistEntry("VRCFury - VFServiceAttribute",
            new[] { "Editor-Common", "Injector", "VFServiceAttribute.cs" },
            new[] { "78fd149e8f8e7db559f441d1b1f3e1a7e025ddc8f1ac11c9476bf4d70e0bfab0" }, (10, 11)),

        new WhitelistEntry("VRCFury - VRCFuryInjector",
            new[] { "Editor-Common", "Injector", "VRCFuryInjector.cs" },
            new[] { "3240a9c4b46b6fccde40c36fe3bdd081b2aa37361bd578ced99c445732c0fe24" }, (160, 161)),

        new WhitelistEntry("VRCFury - BindingBlock",
            new[] { "Editor-Common", "Inspector", "BindingBlock.cs" },
            new[] { "4be903999cf3ece0ef87f92531818705bb2a41af6dcff70e40a0d42329baa3f2" }, (21, 22)),

        new WhitelistEntry("VRCFury - DepthActionSlider",
            new[] { "Editor-Common", "Inspector", "DepthActionSlider.cs" },
            new[] { "db1d777d5c7f3799774d664a61d29c09263edeeebec4091c542a62e257bab80c" }, (106, 107)),

        new WhitelistEntry("VRCFury - SpsEditorUtils",
            new[] { "Editor-Common", "Inspector", "SpsEditorUtils.cs" },
            new[] { "85484b186ff8b6f3dc386a644c753065c0c0b278739b9d8471af30defc894f70" }, (25, 26)),

        new WhitelistEntry("VRCFury - TextFieldWithPlaceholder",
            new[] { "Editor-Common", "Inspector", "TextFieldWithPlaceholder.cs" },
            new[] { "baad3c8569f048058223dc67024ef0a237aa39d752ad1b4eb13d54f9cd1f690c" }, (43, 44)),

        new WhitelistEntry("VRCFury - VRCFuryActionSetDrawer",
            new[] { "Editor-Common", "Inspector", "VRCFuryActionSetDrawer.cs" },
            new[] { "fe1bb75ef53f7e1294ba01606b61818c1b277a583b0498e0a6067baeda795469" }, (105, 106)),

        new WhitelistEntry("VRCFury - VRCFuryComponentEditor",
            new[] { "Editor-Common", "Inspector", "VRCFuryComponentEditor.cs" },
            new[] { "6753d6473d2b5ff92000996bc9b301c799274f58808c421f3e00f7dfb77aee5c" }, (231, 232)),

        new WhitelistEntry("VRCFury - VRCFuryComponentHeader",
            new[] { "Editor-Common", "Inspector", "VRCFuryComponentHeader.cs" },
            new[] { "82eccb314b8194ab443069d9d1271ec57db0b3bf15f05955a39c8ca0af223fcf" }, (155, 156)),

        new WhitelistEntry("VRCFury - VRCFuryEditor",
            new[] { "Editor-Common", "Inspector", "VRCFuryEditor.cs" },
            new[] { "b3bb80fc3efae78dab2799bd160c5474ca645b5210171dc1961d78d0cd111dbd" }, (97, 98)),

        new WhitelistEntry("VRCFury - VRCFuryEditorUtils",
            new[] { "Editor-Common", "Inspector", "VRCFuryEditorUtils.cs" },
            new[] { "3849c393dc1ab74f06f5e5c0845dcca140acbb858f54346b65da1bb77d3303cc" }, (842, 843)),

        new WhitelistEntry("VRCFury - VRCFuryGizmoUtils",
            new[] { "Editor-Common", "Inspector", "VRCFuryGizmoUtils.cs" },
            new[] { "405daa02ec5ff20875592e1e60cd3ee50d49fb84b46a5318720a087654ef82d6" }, (152, 153)),

        new WhitelistEntry("VRCFury - VRCFuryHapticPlugEditor",
            new[] { "Editor-Common", "Inspector", "VRCFuryHapticPlugEditor.cs" },
            new[] { "3949a2a80df3e642d421222ca8e5f4e61921bd668649ed352db11e2951cc23b2" }, (615, 616)),

        new WhitelistEntry("VRCFury - VRCFuryHapticSocketEditor",
            new[] { "Editor-Common", "Inspector", "VRCFuryHapticSocketEditor.cs" },
            new[] { "db68de9eae67d20f01e0384f5245a3ad3f535e3f9a3a0ce43f646fd13b20d942" }, (518, 519)),

        new WhitelistEntry("VRCFury - VRCFurySearchWindowProvider",
            new[] { "Editor-Common", "Inspector", "VRCFurySearchWindowProvider.cs" },
            new[] { "a8507b789583ccf55ce90255b777597b9e1f8bcef10fc72bda9118eb5f63538f" }, (43, 44)),

        new WhitelistEntry("VRCFury - VrcRegistryConfig",
            new[] { "Editor-Common", "Inspector", "VrcRegistryConfig.cs" },
            new[] { "5cf7a1be378ffaf39b4045a21f516236475d8de48172dd14a8f9f12f404024c8" }, (25, 26)),

        new WhitelistEntry("VRCFury - BlockScriptImportsMenuItem",
            new[] { "Editor-Common", "Menu", "BlockScriptImportsMenuItem.cs" },
            new[] { "54eb04d00cccd6e04095627fe9af809d2598002edf26571b4ed2b2c73268f5ee" }, (33, 34)),

        new WhitelistEntry("VRCFury - CleanupRedundantObjectReferenceOverridesMenuItem",
            new[] { "Editor-Common", "Menu", "CleanupRedundantObjectReferenceOverridesMenuItem.cs" },
            new[] { "0393b65dc4f6f5a89eb65baf4faa72f3becdc11dec844edf9eaeddb96d8055dc" }, (142, 143)),

        new WhitelistEntry("VRCFury - DisableVpmResolverInitMenuItem",
            new[] { "Editor-Common", "Menu", "DisableVpmResolverInitMenuItem.cs" },
            new[] { "7d4c7dc24edfcdf2a2542777a5e781c5326ebb89661e2fe1976531f0745e4615" }, (39, 40)),

        new WhitelistEntry("VRCFury - LogExternalSceneReferencesMenuItem",
            new[] { "Editor-Common", "Menu", "LogExternalSceneReferencesMenuItem.cs" },
            new[] { "abb7c455865197029638f2c92cb73fd4f3df86193d0aacda43cdc36861546be9" }, (74, 75)),

        new WhitelistEntry("VRCFury - MenuItems",
            new[] { "Editor-Common", "Menu", "MenuItems.cs" },
            new[] { "0fa0ca8a4e40c2de995af6cf480b02249637ff3bbd61b99def459f74fb1250bd" }, (164, 165)),

        new WhitelistEntry("VRCFury - PlayModeMenuItem",
            new[] { "Editor-Common", "Menu", "PlayModeMenuItem.cs" },
            new[] { "405aa2441c3abfadc02a3011fda8fc390fc144e2b5505edc3986b45b5dc94ccd" }, (32, 33)),

        new WhitelistEntry("VRCFury - SceneDirtyLoggerMenuItem",
            new[] { "Editor-Common", "Menu", "SceneDirtyLoggerMenuItem.cs" },
            new[] { "eed6a81546a3a58a33c4adf09643687a0fe687b1359361316f5c54c41b21d2ef" }, (98, 99)),

        new WhitelistEntry("VRCFury - SpsDevModeMenuItem",
            new[] { "Editor-Common", "Menu", "SpsDevModeMenuItem.cs" },
            new[] { "63cfd2db5d8c3a30fda1b0d63f534f9a73b011e1f858391c4b905c83c18ab7a3" }, (33, 34)),

        new WhitelistEntry("VRCFury - SpsMenuItem",
            new[] { "Editor-Common", "Menu", "SpsMenuItem.cs" },
            new[] { "6cd9023971c04fc5ab225375b4584d318255e6ddf9dc154f1aaf3d7fbf8b7d35" }, (51, 52)),

        new WhitelistEntry("VRCFury - UseInUploadMenuItem",
            new[] { "Editor-Common", "Menu", "UseInUploadMenuItem.cs" },
            new[] { "b7447fb53f3a3d1b2a6165ebe2a6d994771c017ecc461c27cd86a1ea18887eaa" }, (36, 37)),

        new WhitelistEntry("VRCFury - TmpFilePackage",
            new[] { "Editor-Common", "TmpFilePackage.cs" },
            new[] { "7ae38b12755ffc8ff1c91d7e47b37e2176e0ab34547cbbab41927e02fbe78de2" }, (84, 85)),

        new WhitelistEntry("VRCFury - AnimationClipExtensions",
            new[] { "Editor-Common", "Utils", "AnimationClipExtensions.cs" },
            new[] { "2b8f19dc1a283d1d397c97fe68f102351f9465443f972b539c8eddf000a54d46" }, (397, 398)),

        new WhitelistEntry("VRCFury - AnimationCurveExtensions",
            new[] { "Editor-Common", "Utils", "AnimationCurveExtensions.cs" },
            new[] { "3f6c429dbe98b74e581f0e18e9405978736fa95c1982d5f1eb9dfabf9db62b24" }, (61, 62)),

        new WhitelistEntry("VRCFury - AnimationRewriter",
            new[] { "Editor-Common", "Utils", "AnimationRewriter.cs" },
            new[] { "b78e093ba35b58e3ebd2bf50dd2d2fab9849e5f8362298ee5c9cd8b4c9590e35" }, (119, 120)),

        new WhitelistEntry("VRCFury - AnimationRewriterExtensions",
            new[] { "Editor-Common", "Utils", "AnimationRewriterExtensions.cs" },
            new[] { "126db0d382b908ffbd77ec178d241a02d882b9f1a8b9b18afdd01f03eaa09c99" }, (9, 10)),

        new WhitelistEntry("VRCFury - AnimatorConditionLogic",
            new[] { "Editor-Common", "Utils", "AnimatorConditionLogic.cs" },
            new[] { "de73d0c9a9a804f171d6ee26c9c5cb766301511ce602e636539aaf259b1fb0ca" }, (183, 184)),

        new WhitelistEntry("VRCFury - AnimatorControllerParameterExtensions",
            new[] { "Editor-Common", "Utils", "AnimatorControllerParameterExtensions.cs" },
            new[] { "8db9772be58f015dfa8cebe2f41e91552ab024ef90db6d9cfa204cc03610395d" }, (12, 13)),

        new WhitelistEntry("VRCFury - AnimatorIterator",
            new[] { "Editor-Common", "Utils", "AnimatorIterator.cs" },
            new[] { "7d18136b224eebb4424f32f5589fd47388f9373471559c101f52bfb0f86c3dbf" }, (95, 96)),

        new WhitelistEntry("VRCFury - AnimatorTransitionBaseExtensions",
            new[] { "Editor-Common", "Utils", "AnimatorTransitionBaseExtensions.cs" },
            new[] { "1c0f0c0abe18bf82b99e7b7307ae414344904561efd4a0b1a5a1148803028b97" }, (57, 58)),

        new WhitelistEntry("VRCFury - AsyncUtils",
            new[] { "Editor-Common", "Utils", "AsyncUtils.cs" },
            new[] { "af94f429d77affe4f6ee3bceef77184619c601cd08d03e8cb49253c6a12f1983" }, (24, 25)),

        new WhitelistEntry("VRCFury - AvatarMaskExtensions",
            new[] { "Editor-Common", "Utils", "AvatarMaskExtensions.cs" },
            new[] { "9d686c3c8b49b13906f150120816f0ad83779ce2d4a0ba4fd2c14d768c607d06" }, (141, 142)),

        new WhitelistEntry("VRCFury - BlendTreeExtensions",
            new[] { "Editor-Common", "Utils", "BlendTreeExtensions.cs" },
            new[] { "7ce378720bb13effa80ad2f101a8ce81d4cc8e55f64c4d62d14a8a654f9deb60" }, (66, 67)),

        new WhitelistEntry("VRCFury - BuildTargetUtils",
            new[] { "Editor-Common", "Utils", "BuildTargetUtils.cs" },
            new[] { "a15ea7d3281ae97c2cb69b9a2142e3e7290b3ea87f1e61131ad82d8b0b5e3e99" }, (12, 13)),

        new WhitelistEntry("VRCFury - BulkUpgradeUtils",
            new[] { "Editor-Common", "Utils", "BulkUpgradeUtils.cs" },
            new[] { "ff70d49861adec76d3f74749a43b2ea9afffec995cf643b39d7c3b70da615ca2" }, (90, 91)),

        new WhitelistEntry("VRCFury - ComponentExtensions",
            new[] { "Editor-Common", "Utils", "ComponentExtensions.cs" },
            new[] { "e8c4fab9d0dd929db55ecad4a0a57a33bdfa7c53758b09828f73c4c2a79c6a7e" }, (18, 19)),

        new WhitelistEntry("VRCFury - ConstraintUtils",
            new[] { "Editor-Common", "Utils", "ConstraintUtils.cs" },
            new[] { "7fd4e30b2ffa5bd15bc4a191d741e8f2774e09960ec63393cd605016881aeac4" }, (29, 30)),

        new WhitelistEntry("VRCFury - VFABool",
            new[] { "Editor-Common", "Utils", "Controller", "VFABool.cs" },
            new[] { "1eae7b6874abea83afb248653aaed88f6b44f4b170d19253a5deed9b0f8937e6" }, (26, 27)),

        new WhitelistEntry("VRCFury - VFAFloat",
            new[] { "Editor-Common", "Utils", "Controller", "VFAFloat.cs" },
            new[] { "8f7a433dd60fbecdf5d650d2bc4d44f1e744825593e8e2886468779bb82dc8ed" }, (29, 30)),

        new WhitelistEntry("VRCFury - VFAInteger",
            new[] { "Editor-Common", "Utils", "Controller", "VFAInteger.cs" },
            new[] { "3e5baf92a67962ee67019159270fff7ced0346b2a7dc2380c669df4656b1b0e7" }, (25, 26)),

        new WhitelistEntry("VRCFury - VFAParam",
            new[] { "Editor-Common", "Utils", "Controller", "VFAParam.cs" },
            new[] { "5b69dd9cf421bc9833ee8f0c27991ad3241973ea0635b055be1d1d0a2bb9a1cf" }, (19, 20)),

        new WhitelistEntry("VRCFury - VFBehaviourContainer",
            new[] { "Editor-Common", "Utils", "Controller", "VFBehaviourContainer.cs" },
            new[] { "a45e8d7185333c0c39366e1a69546f1779336606f044fac6cb74a73de89444ce" }, (48, 49)),

        new WhitelistEntry("VRCFury - VFCondition",
            new[] { "Editor-Common", "Utils", "Controller", "VFCondition.cs" },
            new[] { "421c035895ace2225bc2245ff7a09a4a295f247a763c79b0d2402962904e8a13" }, (51, 52)),

        new WhitelistEntry("VRCFury - VFController",
            new[] { "Editor-Common", "Utils", "Controller", "VFController.cs" },
            new[] { "41b3dec540870340f8c93644bfda8ef49060fcc038d9e5261b25cae7ee43e77a" }, (647, 648)),

        new WhitelistEntry("VRCFury - VFEntryTransition",
            new[] { "Editor-Common", "Utils", "Controller", "VFEntryTransition.cs" },
            new[] { "b116b08a621d2b60ad7546e0bb6a7e4cebd33bf26e9077a9721cde0f5417f372" }, (24, 25)),

        new WhitelistEntry("VRCFury - VFLayer",
            new[] { "Editor-Common", "Utils", "Controller", "VFLayer.cs" },
            new[] { "b1f44ffcfa5b37d33fb207c38e000a9818292917da4e770390e641b8782cf74c" }, (236, 237)),

        new WhitelistEntry("VRCFury - VFPrettyNamed",
            new[] { "Editor-Common", "Utils", "Controller", "VFPrettyNamed.cs" },
            new[] { "50f07708821619d38d8c34a445d4cd418f8bff40a656d301463c2f400fadf971" }, (5, 6)),

        new WhitelistEntry("VRCFury - VFState",
            new[] { "Editor-Common", "Utils", "Controller", "VFState.cs" },
            new[] { "cf9698f06378526db3e9af7652c3f26d08cca2a6c756e6592bafd35fd405ae83" }, (154, 155)),

        new WhitelistEntry("VRCFury - VFStateMachine",
            new[] { "Editor-Common", "Utils", "Controller", "VFStateMachine.cs" },
            new[] { "60341bd66ad7a5830a41d1e9b4ddf4943244bd6a7c7b64fa19e7af4cd7ab2360" }, (28, 29)),

        new WhitelistEntry("VRCFury - VFTransition",
            new[] { "Editor-Common", "Utils", "Controller", "VFTransition.cs" },
            new[] { "f6d557cf9554d6c0add3af8caf77c6de6b0ce8d1eb0b01c390f49cc35001fecc" }, (93, 94)),

        new WhitelistEntry("VRCFury - DialogUtils",
            new[] { "Editor-Common", "Utils", "DialogUtils.cs" },
            new[] { "a8fad2b393ec7a8dae636c4a4e2d015a6f8c21ff46269bbd91c50d84749c5742" }, (84, 85)),

        new WhitelistEntry("VRCFury - DirtyUtils",
            new[] { "Editor-Common", "Utils", "DirtyUtils.cs" },
            new[] { "de2e843671e7973da5fc686f1df76cf198e0bafc07127e8fe59e48f7718c975e" }, (37, 38)),

        new WhitelistEntry("VRCFury - EditorCurveBindingExtensions",
            new[] { "Editor-Common", "Utils", "EditorCurveBindingExtensions.cs" },
            new[] { "75b3b6b0a57e2b2ce74790352bd45acdc10ccd51196b78bf5fa4781e248b5974" }, (105, 106)),

        new WhitelistEntry("VRCFury - EditorCurveBindingType",
            new[] { "Editor-Common", "Utils", "EditorCurveBindingType.cs" },
            new[] { "64821590c17988b25e0b8f09f4025591016942284d8c2d1db85ca575f70e7bc3" }, (7, 8)),

        new WhitelistEntry("VRCFury - EditorOnlyUtils",
            new[] { "Editor-Common", "Utils", "EditorOnlyUtils.cs" },
            new[] { "eb5e823d42f9f36bc2cc7d19f90fdb12391d0fb3a5ef180163e6e52cb34273f7" }, (48, 49)),

        new WhitelistEntry("VRCFury - EditorWindowFinder",
            new[] { "Editor-Common", "Utils", "EditorWindowFinder.cs" },
            new[] { "90366b648d7b23cfdd182ef90ac0f72224c47b2a82cdb911f9d6ef9ad2835a36" }, (34, 35)),

        new WhitelistEntry("VRCFury - EnumerableExtensions",
            new[] { "Editor-Common", "Utils", "EnumerableExtensions.cs" },
            new[] { "e7d9acad952682c861158c34290011af8e7caf3107cc459383070bd1e444a780" }, (58, 59)),

        new WhitelistEntry("VRCFury - FloatOrObject",
            new[] { "Editor-Common", "Utils", "FloatOrObject.cs" },
            new[] { "be25f412d08164eef3ee475562559be0039db27a882d9db8363bf0b9fd1f1f69" }, (64, 65)),

        new WhitelistEntry("VRCFury - FloatOrObjectCurve",
            new[] { "Editor-Common", "Utils", "FloatOrObjectCurve.cs" },
            new[] { "f8da1f98886f637abcba5d80b991449ef776d5a863894019ff2072430da17c04" }, (142, 143)),

        new WhitelistEntry("VRCFury - GameObjects",
            new[] { "Editor-Common", "Utils", "GameObjects.cs" },
            new[] { "a6d45d1b533e19e00200357ef375d0006564228db6485862a51e671ff970817f" }, (32, 33)),

        new WhitelistEntry("VRCFury - HarmonyTranspiler",
            new[] { "Editor-Common", "Utils", "HarmonyTranspiler.cs" },
            new[] { "3901a0d21e2131114ab40b8830b3e5994d9e71c4b35f72bd971bf43c9810bca6" }, (253, 254)),

        new WhitelistEntry("VRCFury - HarmonyUtils",
            new[] { "Editor-Common", "Utils", "HarmonyUtils.cs" },
            new[] { "711eb9517b9d9e3ffd2f8c742dbc6a36b3220b2b2f93271d9a924d896bed51ad" }, (218, 219)),

        new WhitelistEntry("VRCFury - IConstraintExtensions",
            new[] { "Editor-Common", "Utils", "IConstraintExtensions.cs" },
            new[] { "11d7e79e17e40a3af4010f7edeef310c2cb14ae146c62f3507cd59a92c7798c6" }, (10, 11)),

        new WhitelistEntry("VRCFury - MainWindowUtils",
            new[] { "Editor-Common", "Utils", "MainWindowUtils.cs" },
            new[] { "c06fd1ab4bbcc525e23034d21c0fb55169f8a467738e8b84ab902d4f922ad897" }, (44, 45)),

        new WhitelistEntry("VRCFury - MaterialExtensions",
            new[] { "Editor-Common", "Utils", "MaterialExtensions.cs" },
            new[] { "c79ee9c4261859c5ed296217563bae6d75e2c9e2d6b79b367104e3f759ba40ed" }, (22, 23)),

        new WhitelistEntry("VRCFury - MaterialLocker",
            new[] { "Editor-Common", "Utils", "MaterialLocker.cs" },
            new[] { "774d58a7b1f9d272073a435cea2cd90449fe0b4e9825b0cc0e8c4c3c8c9c2f84" }, (72, 73)),

        new WhitelistEntry("VRCFury - MeshExtensions",
            new[] { "Editor-Common", "Utils", "MeshExtensions.cs" },
            new[] { "feffb45926bb3df18c27a9c24c091fe7675b3faea572b5463e6d1962bb6ffabd" }, (14, 15)),

        new WhitelistEntry("VRCFury - MotionExtensions",
            new[] { "Editor-Common", "Utils", "MotionExtensions.cs" },
            new[] { "a2fa43b8c1e806c7aaf44fade809c3ada7d35cd0f92c2edd61a14de631ebe21a" }, (108, 109)),

        new WhitelistEntry("VRCFury - MutableManager",
            new[] { "Editor-Common", "Utils", "MutableManager.cs" },
            new[] { "338b68eddf64292b5912089e1e4363b4e8e3018ccf63dbe0340dd028776a0737" }, (128, 129)),

        new WhitelistEntry("VRCFury - ObjectExtensions",
            new[] { "Editor-Common", "Utils", "ObjectExtensions.cs" },
            new[] { "fa4c099cc9c896ba22eafd3e4e89ef1dc71ded17a6685ac545b6065ab9597151" }, (101, 102)),

        new WhitelistEntry("VRCFury - OneOrMany",
            new[] { "Editor-Common", "Utils", "OneOrMany.cs" },
            new[] { "44289018545858bd5b2cb69bbf448b6c79b29b596c1ab02577a66b7010dd7132" }, (24, 25)),

        new WhitelistEntry("VRCFury - PhysboneUtils",
            new[] { "Editor-Common", "Utils", "PhysboneUtils.cs" },
            new[] { "beb3a420fd8ff7c4e7fe92e4815a31fb10f0589ff045920cc6e1faa1c182a560" }, (50, 51)),

        new WhitelistEntry("VRCFury - PoiyomiUtils",
            new[] { "Editor-Common", "Utils", "PoiyomiUtils.cs" },
            new[] { "efd7181eb5aa3a2bf24914523a604e1220089c393d659586cefb6d1988ea2066" }, (140, 141)),

        new WhitelistEntry("VRCFury - PolyfillExtensions",
            new[] { "Editor-Common", "Utils", "PolyfillExtensions.cs" },
            new[] { "a40eb3fe76e456567bd6d8fdaaf04753b13867a74d4bd75894d0094cc9f0b934" }, (19, 20)),

        new WhitelistEntry("VRCFury - PrefabUtils",
            new[] { "Editor-Common", "Utils", "PrefabUtils.cs" },
            new[] { "ac7215bfa2dcf607b5ec81a0d09e602d9f0fc38dc523f485a8ecf57a6fa70826" }, (16, 17)),

        new WhitelistEntry("VRCFury - ReflectionHelper",
            new[] { "Editor-Common", "Utils", "ReflectionHelper.cs" },
            new[] { "eef9010e5545be1f88092d413eb32ea1b8aee74f9b0b1c110ea6793bcdc5c3de" }, (54, 55)),

        new WhitelistEntry("VRCFury - ReflectionUtils",
            new[] { "Editor-Common", "Utils", "ReflectionUtils.cs" },
            new[] { "226e258f2b7ea0b30dd790e73dc426173eae01bf5c499c70ee16f6594ae1eb7d" }, (79, 80)),

        new WhitelistEntry("VRCFury - RendererExtensions",
            new[] { "Editor-Common", "Utils", "RendererExtensions.cs" },
            new[] { "51e3f7a6288f23a5a23480634ee5dbe3899c04a2b4543dcda52657f459762289" }, (126, 127)),

        new WhitelistEntry("VRCFury - SaveAssetsSession",
            new[] { "Editor-Common", "Utils", "SaveAssetsSession.cs" },
            new[] { "5c0239f86731d1d4971705e272edad206ef4dec0034127935d68aec9d5051a99" }, (153, 154)),

        new WhitelistEntry("VRCFury - SceneExtensions",
            new[] { "Editor-Common", "Utils", "SceneExtensions.cs" },
            new[] { "a1ba993b2c2f3b43274dc11d7230db0d535d540256d847c65bc5b8c6173b024a" }, (11, 12)),

        new WhitelistEntry("VRCFury - Scheduler",
            new[] { "Editor-Common", "Utils", "Scheduler.cs" },
            new[] { "b0085059c7d8af2eb2ae761e414f66b97f66f465890d55b2fbb916f7b60fe0f4" }, (40, 41)),

        new WhitelistEntry("VRCFury - SerializedObjectExtensions",
            new[] { "Editor-Common", "Utils", "SerializedObjectExtensions.cs" },
            new[] { "75595e77f42df8bf25ab35fe943d5a1010fcb17f087192077c6e4e8e47db728b" }, (49, 50)),

        new WhitelistEntry("VRCFury - SerializedPropertyExtensions",
            new[] { "Editor-Common", "Utils", "SerializedPropertyExtensions.cs" },
            new[] { "6d8e55b7d66e63c84c59b9114409a581fb4041379eb8a9d8c49ffac8088f41bd" }, (61, 62)),

        new WhitelistEntry("VRCFury - SimpleObjectExtensions",
            new[] { "Editor-Common", "Utils", "SimpleObjectExtensions.cs" },
            new[] { "18e8eed7e9f09e2e80abe0c4f20407f13c6d06b9bc140b07d3afef54d96f54c1" }, (18, 19)),

        new WhitelistEntry("VRCFury - SkinnedMeshRendererExtensions",
            new[] { "Editor-Common", "Utils", "SkinnedMeshRendererExtensions.cs" },
            new[] { "d8ef06f8b146ac2ef4b48852aec4dc2f2e2b67cbc2bfb1ff3b7a592871e56a67" }, (18, 19)),

        new WhitelistEntry("VRCFury - StringExtensions",
            new[] { "Editor-Common", "Utils", "StringExtensions.cs" },
            new[] { "45a7f4e8b396ee4cfb0b281eff32b9c9aacb7ef57c1ad954b88e18db66e6d42c" }, (29, 30)),

        new WhitelistEntry("VRCFury - Texture2DExtensions",
            new[] { "Editor-Common", "Utils", "Texture2DExtensions.cs" },
            new[] { "a8f838b92804917e39b6672a017802c148aca1a30d10757b67d4d38bbb6e280a" }, (88, 89)),

        new WhitelistEntry("VRCFury - TypeExtensions",
            new[] { "Editor-Common", "Utils", "TypeExtensions.cs" },
            new[] { "fa25023634c66e9b29928cf0476830a5c7f957234ebebe9831eaf7b663aa696e" }, (93, 94)),

        new WhitelistEntry("VRCFury - UnityCompatUtils",
            new[] { "Editor-Common", "Utils", "UnityCompatUtils.cs" },
            new[] { "61103b54bc0e99ff5c74f11f12da66c98bcc0b9f5f85a55fe93a9998689cd2ba" }, (56, 57)),

        new WhitelistEntry("VRCFury - VFBlendTree",
            new[] { "Editor-Common", "Utils", "VFBlendTree.cs" },
            new[] { "7ccd2e163a68576a81c2ea1788560ab00117ecf42284daea4f429023d92ef527" }, (134, 135)),

        new WhitelistEntry("VRCFury - VFConstraint",
            new[] { "Editor-Common", "Utils", "VFConstraint.cs" },
            new[] { "eaed2dc448d59ec1a705656caf1ec599d8064113d33c98ddea1a11738c58f1e0" }, (135, 136)),

        new WhitelistEntry("VRCFury - VFGameObject",
            new[] { "Editor-Common", "Utils", "VFGameObject.cs" },
            new[] { "79ce0f00d8052a2c5339afb5f6761489a036c41c96e34f0f7bf47a1a3eb6b5cc" }, (320, 321)),

        new WhitelistEntry("VRCFury - VFGameObjectExtensions",
            new[] { "Editor-Common", "Utils", "VFGameObjectExtensions.cs" },
            new[] { "437a041e3ff49325f90b1fe4e7759e8abb6e327e507816d6d3ea7a028028e945" }, (36, 37)),

        new WhitelistEntry("VRCFury - VFMultimap",
            new[] { "Editor-Common", "Utils", "VFMultimap.cs" },
            new[] { "cd9cbea4572dd2718187b1636c95d31a49e5ca754c8ca68bf8a0eb874f18d53f" }, (64, 65)),

        new WhitelistEntry("VRCFury - VfVisualElementExtensions",
            new[] { "Editor-Common", "Utils", "VfVisualElementExtensions.cs" },
            new[] { "1fd8dd5dae143d96c0fd29b12e1b7722373e4201428ab5d6df11d0b0ac3dae11" }, (161, 162)),

        new WhitelistEntry("VRCFury - VRCFEnumUtils",
            new[] { "Editor-Common", "Utils", "VRCFEnumUtils.cs" },
            new[] { "5fc0c7ff146a65d220403873733b902849d947665e9848a370eab0b6236a488a" }, (31, 32)),

        new WhitelistEntry("VRCFury - VrcfMath",
            new[] { "Editor-Common", "Utils", "VrcfMath.cs" },
            new[] { "680e986c014937fe36c274c553daaa0c424f3aeea85c806833ba29217b258bb3" }, (21, 22)),

        new WhitelistEntry("VRCFury - VrcfObjectCloner",
            new[] { "Editor-Common", "Utils", "VrcfObjectCloner.cs" },
            new[] { "674c11ad69d0bbad277d1c16a7b8477f808574919ec444c6117e6429fa946877" }, (78, 79)),

        new WhitelistEntry("VRCFury - VrcfObjectFactory",
            new[] { "Editor-Common", "Utils", "VrcfObjectFactory.cs" },
            new[] { "a3495600440c29b3c72d5099619b2d33b92c2fab036cb73419b919c5848851ec" }, (92, 93)),

        new WhitelistEntry("VRCFury - VrcfObjectId",
            new[] { "Editor-Common", "Utils", "VrcfObjectId.cs" },
            new[] { "112a2cde30285c7e8eb50f853228d77b7b4c7bf50d1f95db11fa894f0824f1e1" }, (99, 100)),

        new WhitelistEntry("VRCFury - VRCFuryAssetDatabase",
            new[] { "Editor-Common", "Utils", "VRCFuryAssetDatabase.cs" },
            new[] { "22b3d2b8aecc00ac80d68e77afd1f0ebabb3556933e219f6ee34651f5a4ec7ce" }, (269, 270)),

        new WhitelistEntry("VRCFury - VRCFuryHideGizmoUnlessSelectedExtensions",
            new[] { "Editor-Common", "Utils", "VRCFuryHideGizmoUnlessSelectedExtensions.cs" },
            new[] { "aaca5b58dc45172bcd77cdc7b7198d01704258dd19bfead40c82fd8b3334dba4" }, (20, 21)),

        new WhitelistEntry("VRCFury - VRCFuryComponentExtensions",
            new[] { "Editor-Common", "VRCFuryComponentExtensions.cs" },
            new[] { "118ab67147954090823a0b386f901682bca89eee14799197c9c010694b5628c8" }, (91, 92)),

        new WhitelistEntry("VRCFury - BuildInjectUnityActions",
            new[] { "Editor-Worlds", "Features", "BuildInjectUnityActions.cs" },
            new[] { "fa0ee2d2707dbd34e47bd21c467c97ce6d18a928d25c25186472d00d7df0d925" }, (119, 120)),

        new WhitelistEntry("VRCFury - BuildMarker",
            new[] { "Editor-Worlds", "Features", "BuildMarker.cs" },
            new[] { "0e05627d110169166939564988d1f8086e32c54465b542c943b6cd0ac4257f51" }, (11, 12)),

        new WhitelistEntry("VRCFury - BuildSps",
            new[] { "Editor-Worlds", "Features", "BuildSps.cs" },
            new[] { "f94155d64b1534013c7c296dd75a189f2ab0cf9af3589ddfee0e42c1ef1a28a1" }, (43, 44)),

        new WhitelistEntry("VRCFury - ComponentInjects",
            new[] { "Editor-Worlds", "Features", "ComponentInjects.cs" },
            new[] { "d292571f4adcb114eb69bc584c14f2070bb651d66e1fcd429bf5d30cdc7bb63e" }, (121, 122)),

        new WhitelistEntry("VRCFury - ApplyVrcfuryHook",
            new[] { "Editor-Worlds", "Hooks", "ApplyVrcfuryHook.cs" },
            new[] { "6fa0afd5b1d15307c5e0dd35df49864142c7bc475e4cc794424979426a54761c" }, (47, 48)),

        new WhitelistEntry("VRCFury - BakeryStaticBatchPlayModeFixHook",
            new[] { "Editor-Worlds", "Hooks", "BakeryStaticBatchPlayModeFixHook.cs" },
            new[] { "95deed0c4a40e90c8f724b5850dc7b171935bd1fb813f62060dfac6879664092" }, (39, 40)),

        new WhitelistEntry("VRCFury - FixTxlPlayerLimitHook",
            new[] { "Editor-Worlds", "Hooks", "FixTxlPlayerLimitHook.cs" },
            new[] { "fa9f06ab62b7c712b3dfa35bbb79c4c3abc1224f0d3a6d72a45f9de6be11c01b" }, (45, 46)),

        new WhitelistEntry("VRCFury - InstantiateMaterialsForPlayModeHook",
            new[] { "Editor-Worlds", "Hooks", "InstantiateMaterialsForPlayModeHook.cs" },
            new[] { "82945d8312bb79f5f7de968a563802e8b41e568d736825df5e824be89d55c927" }, (96, 97)),

        new WhitelistEntry("VRCFury - PreventLightVolumeDirtyHook",
            new[] { "Editor-Worlds", "Hooks", "PreventLightVolumeDirtyHook.cs" },
            new[] { "b8bce22c6c4a2d2e2a8c43b007426a2dda75e1d5ab14df1a9bdf44f0014de9bc" }, (66, 67)),

        new WhitelistEntry("VRCFury - RunBuildRequestInPlayModeHook",
            new[] { "Editor-Worlds", "Hooks", "RunBuildRequestInPlayModeHook.cs" },
            new[] { "d13993a3a5608c18f33691bf67751badb36d293db9810d865872aafd6892ca55" }, (42, 43)),

        new WhitelistEntry("VRCFury - UdonCleanerAssetManager",
            new[] { "Editor-Worlds", "Hooks", "UdonCleaner", "UdonCleanerAssetManager.cs" },
            new[] { "5442bcbd2bee56154c090ff6280f636b4e76b7740f6eb8ee6fd021866f638f7e" }, (345, 346)),

        new WhitelistEntry("VRCFury - UdonCleanerAssetPatcher",
            new[] { "Editor-Worlds", "Hooks", "UdonCleaner", "UdonCleanerAssetPatcher.cs" },
            new[] { "a82412750e89733a7362f30f91f169d7901900026c9cd37a70c47d9f16b6589b" }, (88, 89)),

        new WhitelistEntry("VRCFury - UdonCleanerOdinPrefabManager",
            new[] { "Editor-Worlds", "Hooks", "UdonCleaner", "UdonCleanerOdinPrefabManager.cs" },
            new[] { "be202a4f6ef494b15fc56b3c7438bc0a6e1bd4895694c2be497aa462c4519ebd" }, (246, 247)),

        new WhitelistEntry("VRCFury - UdonCleanerOnBuildHook",
            new[] { "Editor-Worlds", "Hooks", "UdonCleaner", "UdonCleanerOnBuildHook.cs" },
            new[] { "67b40f432e7b7fec509e7eed399e206e4495cd19105db3ff098ea75990228d27" }, (80, 81)),

        new WhitelistEntry("VRCFury - UdonCleanerOnChangeHooks",
            new[] { "Editor-Worlds", "Hooks", "UdonCleaner", "UdonCleanerOnChangeHooks.cs" },
            new[] { "10b3879926483f008432786fe2659931b491a6dd70cb4ba49875468845dd4871" }, (135, 136)),

        new WhitelistEntry("VRCFury - UdonCleanerOnSaveHooks",
            new[] { "Editor-Worlds", "Hooks", "UdonCleaner", "UdonCleanerOnSaveHooks.cs" },
            new[] { "6d9a74c2886f1516e4416ac90174804dbece3b3dfca30f7d54ff2996e1a8fe89" }, (252, 253)),

        new WhitelistEntry("VRCFury - UdonCleanerReflection",
            new[] { "Editor-Worlds", "Hooks", "UdonCleaner", "UdonCleanerReflection.cs" },
            new[] { "e9725bb81c24feb2a7e940487c4c0cfc0b16734e9f0de079b730c86d98b637d6" }, (16, 17)),

        new WhitelistEntry("VRCFury - UdonCleanerSyncMethodManager",
            new[] { "Editor-Worlds", "Hooks", "UdonCleaner", "UdonCleanerSyncMethodManager.cs" },
            new[] { "07691f25b19cf16f9f076f1e68ca5c5bc6a008841b85c763965460193c70a993" }, (103, 104)),

        new WhitelistEntry("VRCFury - UdonCleanerUninstaller",
            new[] { "Editor-Worlds", "Hooks", "UdonCleaner", "UdonCleanerUninstaller.cs" },
            new[] { "7bddd0b5a3bbcf786615ba625636139e2961cbbd9d2224af949c4392a2a9b266" }, (123, 124)),

        new WhitelistEntry("VRCFury - VRCFuryWorldHook",
            new[] { "Editor-Worlds", "Hooks", "VRCFuryWorldHook.cs" },
            new[] { "ab8e2db593a7798d9fa5ce702208d7cf73fd3c6324ed04ade70156559a0b17d5" }, (11, 12)),

        new WhitelistEntry("VRCFury - ClientSimDestroyEditorOnlyFromStartHook",
            new[] { "Editor-Worlds", "Hooks", "VrcsdkFixes", "ClientSimDestroyEditorOnlyFromStartHook.cs" },
            new[] { "b9e01366b2f3fc9eeef38e81adcee32b7c3bf974adb439875b028526c5820c05" }, (58, 59)),

        new WhitelistEntry("VRCFury - ClientSimNetworkingUtilitiesResetHook",
            new[] { "Editor-Worlds", "Hooks", "VrcsdkFixes", "ClientSimNetworkingUtilitiesResetHook.cs" },
            new[] { "2c994e1da1414f7f21066cf308612a32bb4f3ec352e1c379bd26c06d66b6af52" }, (32, 33)),

        new WhitelistEntry("VRCFury - ClientSimPlayerObjectStorageSaveGateHook",
            new[] { "Editor-Worlds", "Hooks", "VrcsdkFixes", "ClientSimPlayerObjectStorageSaveGateHook.cs" },
            new[] { "7535fb7bcaffaac973c489dff98799e9ae141ad56432e8303ed68c6ac26baf8e" }, (70, 71)),

        new WhitelistEntry("VRCFury - DisableUdonBehaviourOnDisableOutsidePlaymodeHook",
            new[] { "Editor-Worlds", "Hooks", "VrcsdkFixes", "DisableUdonBehaviourOnDisableOutsidePlaymodeHook.cs" },
            new[] { "993c0702dffa3bf1a1fe5eacfe9485a0560b00f2f8a8ae22dfc3da869a0c81df" }, (30, 31)),

        new WhitelistEntry("VRCFury - FixBuildAndReloadDoesntSetBuildFlagHook",
            new[] { "Editor-Worlds", "Hooks", "VrcsdkFixes", "FixBuildAndReloadDoesntSetBuildFlagHook.cs" },
            new[] { "fc977bb592d8aa422bbae6b7e5b2c5f4456d1f936fb58d30f07a522dc960cb5f" }, (57, 58)),

        new WhitelistEntry("VRCFury - SpeedUpUdonSharpUpgradesHook",
            new[] { "Editor-Worlds", "Hooks", "VrcsdkFixes", "SpeedUpUdonSharpUpgradesHook.cs" },
            new[] { "b004931254dac507f3ccd633654c52c34e90a19ab973299c8163e8e360d7de5b" }, (46, 47)),

        new WhitelistEntry("VRCFury - SuppressUdonConsoleSpamHook",
            new[] { "Editor-Worlds", "Hooks", "VrcsdkFixes", "SuppressUdonConsoleSpamHook.cs" },
            new[] { "4c0ac63b4fef019d746404af3d640171c170a9af358542e35f64b2cfaee8df9b" }, (77, 78)),

        new WhitelistEntry("VRCFury - UdonSharpCreateScriptSavePanelHook",
            new[] { "Editor-Worlds", "Hooks", "VrcsdkFixes", "UdonSharpCreateScriptSavePanelHook.cs" },
            new[] { "023b46ceb44383d1942b22a3a077a26fc003afc2b896fbd9a85f3953ea6aad0c" }, (34, 35)),

        new WhitelistEntry("VRCFury - UdonSharpInspectorFirstDrawFixHook",
            new[] { "Editor-Worlds", "Hooks", "VrcsdkFixes", "UdonSharpInspectorFirstDrawFixHook.cs" },
            new[] { "ed9a5645cba0284af7a8e54a7f1970b2298a759322411b575072ad14682ac36a" }, (72, 73)),

        new WhitelistEntry("VRCFury - ValueCannotBeNullFixHook",
            new[] { "Editor-Worlds", "Hooks", "VrcsdkFixes", "ValueCannotBeNullFixHook.cs" },
            new[] { "6ff3b7cbcc986615ca1f35c2b1cd31fbd00810632a133b44601964beb79dc431" }, (44, 45)),

        new WhitelistEntry("VRCFury - UdonDiInjectFieldEditor",
            new[] { "Editor-Worlds", "Inspector", "UdonDiInjectFieldEditor.cs" },
            new[] { "1b19829ddb8b3f0272c462ceda964bca430a560070c19e6831e27a2a62e903df" }, (27, 28)),

        new WhitelistEntry("VRCFury - UdonDiRegisterEditor",
            new[] { "Editor-Worlds", "Inspector", "UdonDiRegisterEditor.cs" },
            new[] { "56bb78c264382eaca7b4bfab44ad3a781c809cd99b443e3b1f99e9d62cfb3f56" }, (19, 20)),

        new WhitelistEntry("VRCFury - ApplySuperSampledUiMaterialOverridesMenuItem",
            new[] { "Editor-Worlds", "Menu", "ApplySuperSampledUiMaterialOverridesMenuItem.cs" },
            new[] { "24bf393f4838b53a37103b556aea35059ff85a082cce7e7b51ceb06274fba01d" }, (144, 145)),

        new WhitelistEntry("VRCFury - UdonCleanerMenuItem",
            new[] { "Editor-Worlds", "Menu", "UdonCleanerMenuItem.cs" },
            new[] { "e45d384e537e95e42a7c7aae65339a077c85a96fa46f70b307f7fe6a0dab2f44" }, (134, 135)),

        new WhitelistEntry("VRCFury - FuryActionSet",
            new[] { "PublicApi", "Actions", "FuryActionSet.cs" },
            new[] { "e83e670893efa54a081ffda2264c8b7fe6b87e9743c2121a7bee24a75c19a7f0" }, (57, 58)),

        new WhitelistEntry("VRCFury - FuryFlipbookBuilder",
            new[] { "PublicApi", "Actions", "FuryFlipbookBuilder.cs" },
            new[] { "09d8b6e0f83ed2875b92e73a0909de3454eb552c00e44b231c9c98f658dcd319" }, (32, 33)),

        new WhitelistEntry("VRCFury - FuryArmatureLink",
            new[] { "PublicApi", "Components", "FuryArmatureLink.cs" },
            new[] { "1ad4f186d2a7bed9f5b331a46a019150314ef7fb4542c33d2191fa7245e0c367" }, (69, 70)),

        new WhitelistEntry("VRCFury - FuryFullController",
            new[] { "PublicApi", "Components", "FuryFullController.cs" },
            new[] { "e7d14b62e24f57a8306a01a192f409594235a561bd9207844c018fa86f3e4d83" }, (54, 55)),

        new WhitelistEntry("VRCFury - FurySocket",
            new[] { "PublicApi", "Components", "FurySocket.cs" },
            new[] { "cf6bf67e6fea2f8031cbbc83620089527d52edbd8b89d7a253645cbba0b36420" }, (53, 54)),

        new WhitelistEntry("VRCFury - FuryToggle",
            new[] { "PublicApi", "Components", "FuryToggle.cs" },
            new[] { "4cd6d5759e214afa039df8cdebf35f16ac2802028cb9c9a9c51b9dc2f5e6d2c9" }, (54, 55)),

        new WhitelistEntry("VRCFury - FuryComponents",
            new[] { "PublicApi", "FuryComponents.cs" },
            new[] { "b1413bbdcda5c0105df82192ae47ef20c8891401d710fa9aba87c19f4c912d45" }, (26, 27)),

        new WhitelistEntry("VRCFury - FuryUtils",
            new[] { "PublicApi", "FuryUtils.cs" },
            new[] { "2e1125d5759fa83ffe6cc3d8090a7eef7a1b2f453bc4327c177ee96097ca444c" }, (17, 18)),

        new WhitelistEntry("VRCFury - _InternalsVisibleTo",
            new[] { "Runtime", "_InternalsVisibleTo.cs" },
            new[] { "0149b080d47e361dc03118ca059ae83e68c6cb58ab3775aef70763e43ece8ca1" }, (8, 9)),

        new WhitelistEntry("VRCFury - VRCFuryComponent",
            new[] { "Runtime", "Component", "VRCFuryComponent.cs" },
            new[] { "aca9fa72f74b198939fdac817d28525be294572c991f821019348769a04f7eb1" }, (32, 33)),

        new WhitelistEntry("VRCFury - VRCFuryGlobalCollider",
            new[] { "Runtime", "Component", "VRCFuryGlobalCollider.cs" },
            new[] { "95ba72fe2fc0bdeb7872ec648e331f9d44364fd2c094ed3e2c77c1080a750c88" }, (14, 15)),

        new WhitelistEntry("VRCFury - VRCFuryHapticPlug",
            new[] { "Runtime", "Component", "VRCFuryHapticPlug.cs" },
            new[] { "730ffbdcc787522c029dc37641b6f893098f0c75cc416c822acc614397eea90e" }, (119, 120)),

        new WhitelistEntry("VRCFury - VRCFuryHapticSocket",
            new[] { "Runtime", "Component", "VRCFuryHapticSocket.cs" },
            new[] { "76964df5ccc9c7eff4cf3faf3ddeadcc32c2cf1f2337ce50e9dd3db30a72d685" }, (162, 163)),

        new WhitelistEntry("VRCFury - VRCFuryHapticTouchReceiver",
            new[] { "Runtime", "Component", "VRCFuryHapticTouchReceiver.cs" },
            new[] { "1a35330e75aa42c7c3341ca18819494258e05c3bc2b30e6e52a835234f3863ad" }, (9, 10)),

        new WhitelistEntry("VRCFury - VRCFuryHapticTouchSender",
            new[] { "Runtime", "Component", "VRCFuryHapticTouchSender.cs" },
            new[] { "53eba988f7a3281352f4b86009915464e790b7cce84d99470b290c7031abe1c5" }, (8, 9)),

        new WhitelistEntry("VRCFury - VRCFuryHideGizmoUnlessSelected",
            new[] { "Runtime", "Component", "VRCFuryHideGizmoUnlessSelected.cs" },
            new[] { "dccfdf580d8bedbc1b04b24a66bfb380c3a73a5e9308c9291965669e0782500a" }, (35, 36)),

        new WhitelistEntry("VRCFury - VRCFuryNoUpdateWhenOffscreen",
            new[] { "Runtime", "Component", "VRCFuryNoUpdateWhenOffscreen.cs" },
            new[] { "a28c712a065cce476eb0e6ddada9160759507648e12fadcce7e4e545a1767ef7" }, (12, 13)),

        new WhitelistEntry("VRCFury - VRCFuryPlayComponent",
            new[] { "Runtime", "Component", "VRCFuryPlayComponent.cs" },
            new[] { "70f360ad8cd6fb8470806f5a0c1e508c10e736d87e5f9f2697a6b0fff2b99351" }, (13, 14)),

        new WhitelistEntry("VRCFury - VRCFurySocketGizmo",
            new[] { "Runtime", "Component", "VRCFurySocketGizmo.cs" },
            new[] { "cb628cda35ac86435d2502d525fd44c4f350209d7b2847789e8a1281caad237b" }, (23, 24)),

        new WhitelistEntry("VRCFury - AdvancedCollider",
            new[] { "Runtime", "Model", "Feature", "AdvancedCollider.cs" },
            new[] { "9deda24161f1bc5ee86064303c51af8441ba9104fa8a94d9eea48b11fe8d8ac5" }, (12, 13)),

        new WhitelistEntry("VRCFury - AnchorOverrideFix",
            new[] { "Runtime", "Model", "Feature", "AnchorOverrideFix.cs" },
            new[] { "4f43cd1b3614586d3f8fdf5929ad4cbb0284f7d966da60ccecb5ec3bf1b383df" }, (10, 11)),

        new WhitelistEntry("VRCFury - AnchorOverrideFix2",
            new[] { "Runtime", "Model", "Feature", "AnchorOverrideFix2.cs" },
            new[] { "dada9c1572120324ace6017382ab9edf6e984747aab0ae83ad6a55aa0f4f2e82" }, (7, 8)),

        new WhitelistEntry("VRCFury - ApplyDuringUpload",
            new[] { "Runtime", "Model", "Feature", "ApplyDuringUpload.cs" },
            new[] { "8221fc0e9b8a5b4d112f3e79da13f69615c6c9dcb900e7f743762f3afd39adb3" }, (10, 11)),

        new WhitelistEntry("VRCFury - ArmatureLink",
            new[] { "Runtime", "Model", "Feature", "ArmatureLink.cs" },
            new[] { "021468bce9ca77fffa1f60468b9cbfd580869aaf072b94bf486a08c68991ec7b" }, (147, 148)),

        new WhitelistEntry("VRCFury - AvatarScale",
            new[] { "Runtime", "Model", "Feature", "AvatarScale.cs" },
            new[] { "fabd6c99ca95dca9c907f7b75396dfe275983c7baaaef1d0c7459d11dfd7ba71" }, (10, 11)),

        new WhitelistEntry("VRCFury - AvatarScale2",
            new[] { "Runtime", "Model", "Feature", "AvatarScale2.cs" },
            new[] { "e684a63bb341ea00e0d3444194d0bee397f154f5905cc3e81293af769e7e2f5a" }, (7, 8)),

        new WhitelistEntry("VRCFury - BlendShapeLink",
            new[] { "Runtime", "Model", "Feature", "BlendShapeLink.cs" },
            new[] { "4b5c45a2b971d19f0c4f151d91b0359d0aa49b530debe187d214a28e0bd8930b" }, (48, 49)),

        new WhitelistEntry("VRCFury - BlendshapeOptimizer",
            new[] { "Runtime", "Model", "Feature", "BlendshapeOptimizer.cs" },
            new[] { "93347c6f02e4bf66c7ac035ec1ee15f0dad534f57183643bf87c42dac43da577" }, (29, 30)),

        new WhitelistEntry("VRCFury - Blinking",
            new[] { "Runtime", "Model", "Feature", "Blinking.cs" },
            new[] { "208909fe6c8365d3e5ff443232e091ace7ea437c134868b71d7d2c8f7cc839bc" }, (53, 54)),

        new WhitelistEntry("VRCFury - BoneConstraint",
            new[] { "Runtime", "Model", "Feature", "BoneConstraint.cs" },
            new[] { "174adf88ccec2fcef7591ecbacfd1f73130fac19846e22bc3c6e6f52f586d306" }, (10, 11)),

        new WhitelistEntry("VRCFury - BoundingBoxFix",
            new[] { "Runtime", "Model", "Feature", "BoundingBoxFix.cs" },
            new[] { "745d4a8e173b3817920509ab9de40dae4fa3175d6f7dd825d63afc6374ac607e" }, (10, 11)),

        new WhitelistEntry("VRCFury - BoundingBoxFix2",
            new[] { "Runtime", "Model", "Feature", "BoundingBoxFix2.cs" },
            new[] { "1b971f528911da57bf7169ee687d8e719aeb684f5dde772c6dfe6cf67cfdcba5" }, (7, 8)),

        new WhitelistEntry("VRCFury - Breathing",
            new[] { "Runtime", "Model", "Feature", "Breathing.cs" },
            new[] { "681eafc26d1704a7fa482810f5efeedcdbcc707edfd402d497567653578df226" }, (56, 57)),

        new WhitelistEntry("VRCFury - ConstraintRetarget",
            new[] { "Runtime", "Model", "Feature", "ConstraintRetarget.cs" },
            new[] { "e5b8043c36beaee9142c70865d7706fe062226059fc5b9cfb68d587cb8cc8690" }, (9, 10)),

        new WhitelistEntry("VRCFury - CrossEyeFix",
            new[] { "Runtime", "Model", "Feature", "CrossEyeFix.cs" },
            new[] { "4fe8f7f5283b2e398259c0fdea0d733236d157d523a1a87574e1eddff1fdc43c" }, (10, 11)),

        new WhitelistEntry("VRCFury - CrossEyeFix2",
            new[] { "Runtime", "Model", "Feature", "CrossEyeFix2.cs" },
            new[] { "6138368dce060b548bd4a270a870c935c1513777a80cc43ea0ecf3e073f51296" }, (7, 8)),

        new WhitelistEntry("VRCFury - DeleteDuringUpload",
            new[] { "Runtime", "Model", "Feature", "DeleteDuringUpload.cs" },
            new[] { "c97caee6b86386311243ef4d181fbcf7be0ae82c6f3afb4b64e90e84b7f94bd2" }, (7, 8)),

        new WhitelistEntry("VRCFury - DescriptorDebug",
            new[] { "Runtime", "Model", "Feature", "DescriptorDebug.cs" },
            new[] { "05298c6f9effcaf026a5859e9011e833b10855c2ad2709035489a3ae24c845a4" }, (7, 8)),

        new WhitelistEntry("VRCFury - DirectTreeOptimizer",
            new[] { "Runtime", "Model", "Feature", "DirectTreeOptimizer.cs" },
            new[] { "d119636580706c37a977ef5c221d9555d244210b49be3d954f8287a2c4f09021" }, (7, 8)),

        new WhitelistEntry("VRCFury - FeatureModel",
            new[] { "Runtime", "Model", "Feature", "FeatureModel.cs" },
            new[] { "1fd8ece18ebec895c716e5930078d2a7c8010a915fc7f862b4b4f8fd69b0c992" }, (21, 22)),

        new WhitelistEntry("VRCFury - FixWriteDefaults",
            new[] { "Runtime", "Model", "Feature", "FixWriteDefaults.cs" },
            new[] { "e1f76af39e52c51d382d851866d63169fccc6ff1685f34d71277bf64c2e1bd54" }, (14, 15)),

        new WhitelistEntry("VRCFury - FullController",
            new[] { "Runtime", "Model", "Feature", "FullController.cs" },
            new[] { "2196aac68ade703e9c3558724e0e8f369f4fb2fe57931e95f5e51d1157ca872f" }, (138, 139)),

        new WhitelistEntry("VRCFury - GestureDriver",
            new[] { "Runtime", "Model", "Feature", "GestureDriver.cs" },
            new[] { "066737980f91cfd879579039759a7d176cee1bd4b1bdc5ca11e233d13ae1bae2" }, (61, 62)),

        new WhitelistEntry("VRCFury - Gizmo",
            new[] { "Runtime", "Model", "Feature", "Gizmo.cs" },
            new[] { "cfa25195f641d1000dc59874b27b5d1af63e4ea357c844343d0bd79c0a570a01" }, (12, 13)),

        new WhitelistEntry("VRCFury - HeadChopHead",
            new[] { "Runtime", "Model", "Feature", "HeadChopHead.cs" },
            new[] { "6a9f8065542f76d8a6a30185de8a9ba38a085226c6d90bf75d6850d9b552e9e8" }, (8, 9)),

        new WhitelistEntry("VRCFury - LegacyFeatureModel",
            new[] { "Runtime", "Model", "Feature", "LegacyFeatureModel.cs" },
            new[] { "5afea4ef4939701ecc852ae8506add4effbf328c3fcc0e0e36dc67ba3897e3bf" }, (18, 19)),

        new WhitelistEntry("VRCFury - MakeWriteDefaultsOff",
            new[] { "Runtime", "Model", "Feature", "MakeWriteDefaultsOff.cs" },
            new[] { "8ce6f90ef594d35f071bfd5a29f7ae3cb2d67cbd1083e9a064d32d77920c13b7" }, (12, 13)),

        new WhitelistEntry("VRCFury - MakeWriteDefaultsOff2",
            new[] { "Runtime", "Model", "Feature", "MakeWriteDefaultsOff2.cs" },
            new[] { "4b80f296e2efc1108973bb02d5d0e3bda1f6f108585aa9ebf8e663667c045bbc" }, (12, 13)),

        new WhitelistEntry("VRCFury - MmdCompatibility",
            new[] { "Runtime", "Model", "Feature", "MmdCompatibility.cs" },
            new[] { "57c32c7edfeedea94c2ca37e1ea4671283e8ae8c60103637e9779b2834ab2283" }, (15, 16)),

        new WhitelistEntry("VRCFury - Modes",
            new[] { "Runtime", "Model", "Feature", "Modes.cs" },
            new[] { "44fcdc18a0fe8712b5faf85bf1aff2c9214612522f6517a38e37a6b9337f7ab3" }, (47, 48)),

        new WhitelistEntry("VRCFury - MoveMenuItem",
            new[] { "Runtime", "Model", "Feature", "MoveMenuItem.cs" },
            new[] { "72133cab1088cd0b640c13149182c9af2bd1c5109cc69f7400f3458f29b76897" }, (33, 34)),

        new WhitelistEntry("VRCFury - NewFeatureModel",
            new[] { "Runtime", "Model", "Feature", "NewFeatureModel.cs" },
            new[] { "266f08c246e19de8b002efe214c5fc81a7fccfdfe3f079afdb37933ec78403f7" }, (21, 22)),

        new WhitelistEntry("VRCFury - ObjectState",
            new[] { "Runtime", "Model", "Feature", "ObjectState.cs" },
            new[] { "b108ab7e10e6c12376dc0de7d2fec7c3dd15081cdc221cf91f9e67eed915b7ea" }, (53, 54)),

        new WhitelistEntry("VRCFury - OGBIntegration",
            new[] { "Runtime", "Model", "Feature", "OGBIntegration.cs" },
            new[] { "30fc9df343bc2d1e26bf9f4fae2dac6dba1ee35118c203d5810ce3ca222fc5f1" }, (10, 11)),

        new WhitelistEntry("VRCFury - OGBIntegration2",
            new[] { "Runtime", "Model", "Feature", "OGBIntegration2.cs" },
            new[] { "3e095d45366c51d40a05ecbcbcafc259cb1e38c1d5b497a61f532f50d6874e6a" }, (7, 8)),

        new WhitelistEntry("VRCFury - OverrideMenuSettings",
            new[] { "Runtime", "Model", "Feature", "OverrideMenuSettings.cs" },
            new[] { "ddfc929cdeb3b57f10763fc54d15d1e2d7d2e54aaf970e934e08e10fb2d43497" }, (9, 10)),

        new WhitelistEntry("VRCFury - Puppet",
            new[] { "Runtime", "Model", "Feature", "Puppet.cs" },
            new[] { "ccc517b34c07eb49a86ff42f91b322e5b8b764c4c9d1da32b3f2c82ffa728a7b" }, (28, 29)),

        new WhitelistEntry("VRCFury - RemoveBlinking",
            new[] { "Runtime", "Model", "Feature", "RemoveBlinking.cs" },
            new[] { "cc4eca1129abdf9cfeb7c2256e1fdf18d0b5ef5601f7b31b2471877cc0462081" }, (7, 8)),

        new WhitelistEntry("VRCFury - RemoveHandGestures",
            new[] { "Runtime", "Model", "Feature", "RemoveHandGestures.cs" },
            new[] { "0b309ac707dfe8d8627da155f9d6bc3ff4347d7c7daf6e202858b03186d2981e" }, (10, 11)),

        new WhitelistEntry("VRCFury - RemoveHandGestures2",
            new[] { "Runtime", "Model", "Feature", "RemoveHandGestures2.cs" },
            new[] { "7616155412258125084ed147e027e1f528f0bb5544db374f4ed54fa0b45c71bc" }, (7, 8)),

        new WhitelistEntry("VRCFury - ReorderMenuItem",
            new[] { "Runtime", "Model", "Feature", "ReorderMenuItem.cs" },
            new[] { "34b8c282fbcb166c61fb11005a457c42f449dede53de71abda1626c01ab04e97" }, (9, 10)),

        new WhitelistEntry("VRCFury - SecurityLock",
            new[] { "Runtime", "Model", "Feature", "SecurityLock.cs" },
            new[] { "23e2474c83c7292498408f70b2ee1b480010bb49fe7e5aa00e96a4c011951c24" }, (8, 9)),

        new WhitelistEntry("VRCFury - SecurityRestricted",
            new[] { "Runtime", "Model", "Feature", "SecurityRestricted.cs" },
            new[] { "367df722e236a88347bde6098a88e72b76700bdd2b6307147bedae8bf7bde9c3" }, (7, 8)),

        new WhitelistEntry("VRCFury - SenkyGestureDriver",
            new[] { "Runtime", "Model", "Feature", "SenkyGestureDriver.cs" },
            new[] { "b832c5d55b56adbf10601b8e3602e62c879d96ff03b20bd99be9f4d5032d830e" }, (21, 22)),

        new WhitelistEntry("VRCFury - SetIcon",
            new[] { "Runtime", "Model", "Feature", "SetIcon.cs" },
            new[] { "adf949dc5cf9c1f506e8b340381c23d8f2a09f886b56fccdc9b8dd80ceaaba55" }, (22, 23)),

        new WhitelistEntry("VRCFury - ShowInFirstPerson",
            new[] { "Runtime", "Model", "Feature", "ShowInFirstPerson.cs" },
            new[] { "bf39237973595d80fc78d8f202b8757d11831b852a09fabdc3f5b69ab7bb660a" }, (11, 12)),

        new WhitelistEntry("VRCFury - Slot4Fix",
            new[] { "Runtime", "Model", "Feature", "Slot4Fix.cs" },
            new[] { "1a51e9d0cf0ef7a5d4cd92ebd92c2a1a4ea1d844b8f3ad76308621ffddb99dfd" }, (7, 8)),

        new WhitelistEntry("VRCFury - SpsOptions",
            new[] { "Runtime", "Model", "Feature", "SpsOptions.cs" },
            new[] { "a38dfbb01008aa066161430ec411d0431c0bfbfaebc3048c617e4dbd244a5b87" }, (10, 11)),

        new WhitelistEntry("VRCFury - Talking",
            new[] { "Runtime", "Model", "Feature", "Talking.cs" },
            new[] { "b35a4d31f4fa76dc5bf105a557fe2eb3d49c11176ff863731ed969c19e467718" }, (8, 9)),

        new WhitelistEntry("VRCFury - Toes",
            new[] { "Runtime", "Model", "Feature", "Toes.cs" },
            new[] { "0399d0e8bf1d674afaa4ef8f9d69cf481518ba4a91a2abad2501f68cf18b34d7" }, (10, 11)),

        new WhitelistEntry("VRCFury - Toggle",
            new[] { "Runtime", "Model", "Feature", "Toggle.cs" },
            new[] { "f7aa1fbf33336eaafda2b5881359a446eaa6da68436b5115c94c963a1317d28c" }, (82, 83)),

        new WhitelistEntry("VRCFury - TPSIntegration",
            new[] { "Runtime", "Model", "Feature", "TPSIntegration.cs" },
            new[] { "c8fdfdbaeed83379f002e259c6f4dd695dbc45a44ea93d7074b249b10a3509f5" }, (10, 11)),

        new WhitelistEntry("VRCFury - TPSIntegration2",
            new[] { "Runtime", "Model", "Feature", "TPSIntegration2.cs" },
            new[] { "954187f51b99e0de905b947cf3f639f242feaab2e9ce0e05d530011fb0734385" }, (7, 8)),

        new WhitelistEntry("VRCFury - TpsScaleFix",
            new[] { "Runtime", "Model", "Feature", "TpsScaleFix.cs" },
            new[] { "a6225ceac9d31e3f1ff50880299ba0128afabefb37e737bb150ad9b4885a1bb1" }, (9, 10)),

        new WhitelistEntry("VRCFury - UnlimitedParameters",
            new[] { "Runtime", "Model", "Feature", "UnlimitedParameters.cs" },
            new[] { "4f288f97255ee4c15fcc677e933fb318a612e0f76f804cb22f7e33da765f1da2" }, (9, 10)),

        new WhitelistEntry("VRCFury - Visemes",
            new[] { "Runtime", "Model", "Feature", "Visemes.cs" },
            new[] { "f16d7e3076394a464d64e23821ad2b93497308168c8f9ed988460ada215df886" }, (37, 38)),

        new WhitelistEntry("VRCFury - WorldConstraint",
            new[] { "Runtime", "Model", "Feature", "WorldConstraint.cs" },
            new[] { "6b941a8f1531cfeaa8f8ed7e37e277b1a1d35ae084caec8bd6bd975ef5fba608" }, (25, 26)),

        new WhitelistEntry("VRCFury - ZawooIntegration",
            new[] { "Runtime", "Model", "Feature", "ZawooIntegration.cs" },
            new[] { "619eef5e16e0321ead42620f38e14a7ea76329f3ea3a7979e6a6a4084f14b36f" }, (8, 9)),

        new WhitelistEntry("VRCFury - GuidWrapper",
            new[] { "Runtime", "Model", "GuidWrapper.cs" },
            new[] { "495e4a7362ed887c0e48f5d26425f3ce35b4e95b87a83d8529bcfb74bdf78e86" }, (126, 127)),

        new WhitelistEntry("VRCFury - State",
            new[] { "Runtime", "Model", "State.cs" },
            new[] { "f14afc5c0e4a229d8070fc6a64c2bcce97c6d707f680e0251c07b173e6aef66c" }, (11, 12)),

        new WhitelistEntry("VRCFury - Action",
            new[] { "Runtime", "Model", "StateAction", "Action.cs" },
            new[] { "2355cef89d9ba2d965dc761a19c7feaa145185b075b54e0b7fbd5e9f80c6511f" }, (14, 15)),

        new WhitelistEntry("VRCFury - AnimationClipAction",
            new[] { "Runtime", "Model", "StateAction", "AnimationClipAction.cs" },
            new[] { "b2e8c3bd2c1438e9258661d1442290e65064e4b4d3a7921fabdeb4a2259b2cf2" }, (10, 11)),

        new WhitelistEntry("VRCFury - BlendShapeAction",
            new[] { "Runtime", "Model", "StateAction", "BlendShapeAction.cs" },
            new[] { "6da37d8ed2d5e9ce215985d39669d0f9794e37abe44a7266d110e1bf55061d30" }, (12, 13)),

        new WhitelistEntry("VRCFury - BlockBlinkingAction",
            new[] { "Runtime", "Model", "StateAction", "BlockBlinkingAction.cs" },
            new[] { "604ee25d127bbbdcf5e9dc0767e7d748c8cb154da001e7b84b7570ae782b5883" }, (7, 8)),

        new WhitelistEntry("VRCFury - BlockVisemesAction",
            new[] { "Runtime", "Model", "StateAction", "BlockVisemesAction.cs" },
            new[] { "584e2fc72c2f4d687b381e1c805d157ae400ac52521c0081e074690e44b9873a" }, (7, 8)),

        new WhitelistEntry("VRCFury - DisableGesturesAction",
            new[] { "Runtime", "Model", "StateAction", "DisableGesturesAction.cs" },
            new[] { "78a28e400ed720935f4752154c64ab78cd68c86ee0a1a7721938af389efbf1e2" }, (7, 8)),

        new WhitelistEntry("VRCFury - DoNotApplyRestingStateAttribute",
            new[] { "Runtime", "Model", "StateAction", "DoNotApplyRestingStateAttribute.cs" },
            new[] { "fa85fc7392adecb6a83003e147c8c78d192f42f8d5166a5e0346a7f925c04fb2" }, (12, 13)),

        new WhitelistEntry("VRCFury - FlipbookAction",
            new[] { "Runtime", "Model", "StateAction", "FlipbookAction.cs" },
            new[] { "87b0b5fdffb4df40bc47c397c8925e2e6e2ee01c72d2d6631cfa572d6fd5187f" }, (26, 27)),

        new WhitelistEntry("VRCFury - FlipBookBuilderAction",
            new[] { "Runtime", "Model", "StateAction", "FlipBookBuilderAction.cs" },
            new[] { "1200b215c0b6ef3fa6418e77fb66518edb13f613f2549ec7fcf0fb230c6f112f" }, (33, 34)),

        new WhitelistEntry("VRCFury - FxFloatAction",
            new[] { "Runtime", "Model", "StateAction", "FxFloatAction.cs" },
            new[] { "5bade36243108003beade13b9f6dfb4299242425c920e903f648276cca165fee" }, (9, 10)),

        new WhitelistEntry("VRCFury - MaterialAction",
            new[] { "Runtime", "Model", "StateAction", "MaterialAction.cs" },
            new[] { "244c35224bb944ba85d242495d38ca8682e5d4f8ad50b852f06cdf1436e3450c" }, (27, 28)),

        new WhitelistEntry("VRCFury - MaterialPropertyAction",
            new[] { "Runtime", "Model", "StateAction", "MaterialPropertyAction.cs" },
            new[] { "1c5dda77d5831550806be73f14f7768cdaa250ea9b59d3a10cc6cf3f5114b249" }, (43, 44)),

        new WhitelistEntry("VRCFury - ObjectToggleAction",
            new[] { "Runtime", "Model", "StateAction", "ObjectToggleAction.cs" },
            new[] { "ee692895f5ed0a5e122925870dfe25a090bbc08b089f84658af4177c2c7cc645" }, (27, 28)),

        new WhitelistEntry("VRCFury - PoiyomiUVTileAction",
            new[] { "Runtime", "Model", "StateAction", "PoiyomiUVTileAction.cs" },
            new[] { "af5a926a74dec3d0bcfc4b4968dd640212c14c953dafc8da1927143a08c17d5f" }, (13, 14)),

        new WhitelistEntry("VRCFury - ResetPhysboneAction",
            new[] { "Runtime", "Model", "StateAction", "ResetPhysboneAction.cs" },
            new[] { "1651ff6601db1985fe51430645acfa23c9cd6645e60b2160bad60075be50399b" }, (9, 10)),

        new WhitelistEntry("VRCFury - ScaleAction",
            new[] { "Runtime", "Model", "StateAction", "ScaleAction.cs" },
            new[] { "c0cec78dc649379c95988e8a7fd76fc1cda95e46dc461eeb3fddc66db891e076" }, (10, 11)),

        new WhitelistEntry("VRCFury - ShaderInventoryAction",
            new[] { "Runtime", "Model", "StateAction", "ShaderInventoryAction.cs" },
            new[] { "557b6cb4176b63629a08593dc2ac3f91dd9c5979add8eb0f5e33c39307ab8843" }, (10, 11)),

        new WhitelistEntry("VRCFury - SmoothLoopAction",
            new[] { "Runtime", "Model", "StateAction", "SmoothLoopAction.cs" },
            new[] { "624f24aac8220bc660889c5616b04047f5f8a2becee80899cec8baee8bf68f65" }, (10, 11)),

        new WhitelistEntry("VRCFury - SpsOnAction",
            new[] { "Runtime", "Model", "StateAction", "SpsOnAction.cs" },
            new[] { "cec69de57faf9c838aa8bb4715186d7397aed5c13858779f6479941055755154" }, (9, 10)),

        new WhitelistEntry("VRCFury - WorldDropAction",
            new[] { "Runtime", "Model", "StateAction", "WorldDropAction.cs" },
            new[] { "aa939d94b1a0d5d9463ebb9fb4ab8e307996278c6369531e0a6228e6de1069b7" }, (9, 10)),

        new WhitelistEntry("VRCFury - VRCFury",
            new[] { "Runtime", "Model", "VRCFury.cs" },
            new[] { "816f38532375ae6de386b4f77b14fb96576bf4b25e3b5f8473723d53f05f8cf4" }, (92, 93)),

        new WhitelistEntry("VRCFury - VRCFuryConfig",
            new[] { "Runtime", "Model", "VRCFuryConfig.cs" },
            new[] { "8cb0d8ca1d04370861a97fe193ba5f1008850111ad73e1073574b8da35e669c7" }, (11, 12)),

        new WhitelistEntry("VRCFury - VRCFuryDebugInfo",
            new[] { "Runtime", "Model", "VRCFuryDebugInfo.cs" },
            new[] { "80f8002fc74e5af87bd5bb299ddcbeb1028b1834ff97e712f23a44e44a59df7d" }, (13, 14)),

        new WhitelistEntry("VRCFury - VRCFuryTest",
            new[] { "Runtime", "Model", "VRCFuryTest.cs" },
            new[] { "561eab9f767fc24d6a704b3bb066d22d2d6300b9b804a37c87111e73a1173553" }, (9, 10)),

        new WhitelistEntry("VRCFury - UnitySerializationUtils",
            new[] { "Runtime", "UnitySerializationUtils.cs" },
            new[] { "3ce60bbd52f5424329450b0365495f6fc2792c19abb6b35edf45c5ae71f4277b" }, (127, 128)),

        new WhitelistEntry("VRCFury - IUpgradeable",
            new[] { "Runtime", "Upgradeable", "IUpgradeable.cs" },
            new[] { "0b84f10381ae369d3f3d7646517b51c82158d9068e6068bd61f268f273ff067e" }, (9, 10)),

        new WhitelistEntry("VRCFury - IUpgradeableUtility",
            new[] { "Runtime", "Upgradeable", "IUpgradeableUtility.cs" },
            new[] { "39c3b36d798d8e8161751953b87a10ea9568fb8d639f201f08a8c42ef2b36510" }, (61, 62)),

        new WhitelistEntry("VRCFury - VrcfUpgradeable",
            new[] { "Runtime", "Upgradeable", "VrcfUpgradeable.cs" },
            new[] { "8ba311ba48652dcaad10d186ea6b9ba205e98dd0b52ef0191c3bf5b9b4a3b675" }, (20, 21)),

        new WhitelistEntry("VRCFury - VrcfUpgradeableMonoBehaviour",
            new[] { "Runtime", "Upgradeable", "VrcfUpgradeableMonoBehaviour.cs" },
            new[] { "a768d9d19f464e83a32654e1e5644543515c3b26dc9d3e761b255b74850d4e36" }, (28, 29)),

        new WhitelistEntry("VRCFury - IVrcfEditorOnly",
            new[] { "Runtime", "VrcfEditorOnly", "IVrcfEditorOnly.cs" },
            new[] { "75a7f576d410aed6c0a4833e1494fa23d9b51f41487caf6d5208e111f2d16088" }, (12, 13)),

        new WhitelistEntry("VRCFury - TestBuild",
            new[] { "Tests", "TestBuild.cs" },
            new[] { "aa6874ad3960306067725eedf5accac3e696e4145521b42babb81f3d53b3965a" }, (31, 32)),

        new WhitelistEntry("VRCFury - _InternalsVisibleTo",
            new[] { "UdonApi", "_InternalsVisibleTo.cs" },
            new[] { "c1839afe45dfcd14fb6a62a7c63d7913539494ae22799bc4aab4a176698b369f" }, (3, 4)),

        new WhitelistEntry("VRCFury - InjectUnityActionAttribute",
            new[] { "UdonApi", "Attributes", "InjectUnityActionAttribute.cs" },
            new[] { "fd688089ee9d8ecaf24bfb51a3bbcb855891f4f122927767bf3ad82baf91c1c5" }, (14, 15)),

        new WhitelistEntry("VRCFury - UdonDiInjectField",
            new[] { "UdonApi", "Components", "UdonDiInjectField.cs" },
            new[] { "46c9fd543093ccf0bd85ae37e701b6b0e77213c25ce5ed5eeaa8c5d76d83acf1" }, (10, 11)),

        new WhitelistEntry("VRCFury - UdonDiRegister",
            new[] { "UdonApi", "Components", "UdonDiRegister.cs" },
            new[] { "bd0ecfdc674d015deb2f9a93fd6b32f3c2ad5a0948c94e7992f4ec99a176f4a1" }, (9, 10)),



        // == PumkinsAvatarTools ====================================================
        // SHA-256 verified whitelist entries. Computed from known-good package.

        new WhitelistEntry("PumkinsAvatarTools - _PumkinsAvatarToolsWindow",
            new[] { "Editor", "_PumkinsAvatarToolsWindow.cs" },
            new[] { "a19bc557b2f9a59b8f7cf293ae03806f9b8282fdc31672c9ff609b29bbb1eb9c" }, (138, 139)),

        new WhitelistEntry("PumkinsAvatarTools - CopyInstance",
            new[] { "Editor", "Copiers", "CopyInstance.cs" },
            new[] { "7a08832cc5e9c0c68bc24ea7ff62eae2c4c4a132ed4441f101edcb3c897a42a3" }, (29, 30)),

        new WhitelistEntry("PumkinsAvatarTools - DynamicCopierTypeCategory",
            new[] { "Editor", "Copiers", "DynamicCopierTypeCategory.cs" },
            new[] { "330bb918fea98a537558d60a2875ef32ba9f34baf5056ada31163aed68c985e4" }, (85, 86)),

        new WhitelistEntry("PumkinsAvatarTools - GenericCopier",
            new[] { "Editor", "Copiers", "GenericCopier.cs" },
            new[] { "7e4fbda0ca4bc78268dc631769cd121f23f1ff7a40b91c5c598541aa45501e17" }, (483, 484)),

        new WhitelistEntry("PumkinsAvatarTools - LegacyCopier",
            new[] { "Editor", "Copiers", "LegacyCopier.cs" },
            new[] { "3b25138915831380c3524378757f4710883721bf92223999949ead9c97b1d097" }, (1216, 1217)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsAvatarInfo",
            new[] { "Editor", "Data", "PumkinsAvatarInfo.cs" },
            new[] { "99d1940bc0be42c6dae5c02e31ef6d8720a482f6c4aa73e45799fa1c04b74526" }, (462, 463)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsDataStructures",
            new[] { "Editor", "Data", "PumkinsDataStructures.cs" },
            new[] { "763d29307e91e3bec99fbee2bc44532936dc8f95a743d1dae418b57573957b87" }, (770, 771)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsStrings",
            new[] { "Editor", "Data", "PumkinsStrings.cs" },
            new[] { "e5b3d31c64965f3adde72321437f1e36bbe8e246343604f4714da3247001b429" }, (963, 964)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsTypeCache",
            new[] { "Editor", "Data", "PumkinsTypeCache.cs" },
            new[] { "0f517de9346c1573336ab6188a77c42b32dc77e0cb2ec7f60da8b8b75aa53148" }, (148, 149)),

        new WhitelistEntry("PumkinsAvatarTools - _DependencyChecker",
            new[] { "Editor", "Dependencies", "_DependencyChecker.cs" },
            new[] { "e686aea7f16c716c04c4c9a5d6da3e9c759e321eaae429106a0ea280471f318e" }, (159, 160)),

        new WhitelistEntry("PumkinsAvatarTools - EditorCoroutine",
            new[] { "Editor", "Dependencies", "EditorCoroutine.cs" },
            new[] { "fbbdf6b9d26b131f95f001035347bf8991d6103037964dc8aa5076ac0fc285ff" }, (54, 55)),

        new WhitelistEntry("PumkinsAvatarTools - ScriptableObjectUtility",
            new[] { "Editor", "Dependencies", "ScriptableObjectUtility.cs" },
            new[] { "4ffebde1bcd127209305a122f4452b6ca56d05fcb87dd7d0109b48bb79eb35e3" }, (72, 73)),

        new WhitelistEntry("PumkinsAvatarTools - ScriptDefinesManager",
            new[] { "Editor", "Dependencies", "ScriptDefinesManager.cs" },
            new[] { "da2b11cf518865f56193dab1c94b19261d3aa27768eed70bd6962f52359e0455" }, (128, 129)),

        new WhitelistEntry("PumkinsAvatarTools - LegacyDestroyer",
            new[] { "Editor", "Destroyers", "LegacyDestroyer.cs" },
            new[] { "d251f0d142dd3ae1a2457f0d693b81502a7ad7922d2909ca51db539ab68de221" }, (163, 164)),

        new WhitelistEntry("PumkinsAvatarTools - AssetDatabaseHelpers",
            new[] { "Editor", "Helpers", "AssetDatabaseHelpers.cs" },
            new[] { "1a22f1e7cdc77d65d3521513c6edabfdca4f741deb190c4dca343ad244cda6a4" }, (17, 18)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsExtensions",
            new[] { "Editor", "Helpers", "PumkinsExtensions.cs" },
            new[] { "d762cc12611fa97ff59c1169aeef6f57a1cd254a3fc600c924b8c05a71b3f3a7" }, (289, 290)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsHelperFunctions",
            new[] { "Editor", "Helpers", "PumkinsHelperFunctions.cs" },
            new[] { "a1bb8ab63af0928d2ff37b0970c5c847069ce024f0a9d8c13bee90e87cd11fbe" }, (1652, 1653)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsSettingsUtility",
            new[] { "Editor", "Helpers", "PumkinsSettingsUtility.cs" },
            new[] { "51b5a63a077cbc94ebe07aad3cc02b7b5a7e9aadae483b74cd69f81a3510a2b0" }, (118, 119)),

        new WhitelistEntry("PumkinsAvatarTools - TypeHelpers",
            new[] { "Editor", "Helpers", "TypeHelpers.cs" },
            new[] { "b7c6e3e08fda77a35c1c4be7ce5a18f66d9fc975b76fbe84572d1ec09fdf28d0" }, (52, 53)),

        new WhitelistEntry("PumkinsAvatarTools - VRChatHelpers",
            new[] { "Editor", "Helpers", "VRChatHelpers.cs" },
            new[] { "f1e419b5cf0c7951af1f188f3bd99e043f55e39fb3a78a94ef30d71da9222898" }, (105, 106)),

        new WhitelistEntry("PumkinsAvatarTools - PrefManager",
            new[] { "Editor", "PrefManager.cs" },
            new[] { "ad14605b1eb8943101125328dd93ea1b44c61d4036bc4cd6680c4ac1f5f022ef" }, (150, 151)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsBlendshapePresetEditor",
            new[] { "Editor", "Presets", "Editors", "PumkinsBlendshapePresetEditor.cs" },
            new[] { "4e5fed276e084d816954d1c79a91d3e734a52868b3e1bdee97781c60e1b32f60" }, (42, 43)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsCameraPresetEditor",
            new[] { "Editor", "Presets", "Editors", "PumkinsCameraPresetEditor.cs" },
            new[] { "4d1c97f7c5c361834d6e081c84481e5cc32ec6f087f930e75a4387c4cc73de41" }, (131, 132)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsPosePresetEditor",
            new[] { "Editor", "Presets", "Editors", "PumkinsPosePresetEditor.cs" },
            new[] { "52a4201fd97c6fb2479e6d3c3656dc06fc05a8dbb27b3bbce790aba9da492118" }, (81, 82)),

        new WhitelistEntry("PumkinsAvatarTools - CreateBlendshapePresetPopup",
            new[] { "Editor", "Presets", "Popups", "CreateBlendshapePresetPopup.cs" },
            new[] { "ccad031c78be76dba161630623d64c3a6519f6a2e7628ff4d3bfb8a2e108ad14" }, (142, 143)),

        new WhitelistEntry("PumkinsAvatarTools - CreateCameraPresetPopup",
            new[] { "Editor", "Presets", "Popups", "CreateCameraPresetPopup.cs" },
            new[] { "8d4ea98b9cc1f6ce1fdac82e3e397ce5cab5315a46d062648f928dc72b259343" }, (230, 231)),

        new WhitelistEntry("PumkinsAvatarTools - CreatePosePresetPopup",
            new[] { "Editor", "Presets", "Popups", "CreatePosePresetPopup.cs" },
            new[] { "d45783febd4b47d690195469a1a5318a368ae5d0c91ae60f83e70ed39e870eee" }, (151, 152)),

        new WhitelistEntry("PumkinsAvatarTools - CreatePresetPopupBase",
            new[] { "Editor", "Presets", "Popups", "CreatePresetPopupBase.cs" },
            new[] { "eaf04078d9dc1c22177a7de7c52fe43f239267cb1bfe62c21fe895b3a337d6d4" }, (52, 53)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsBlendshapePreset",
            new[] { "Editor", "Presets", "PumkinsBlendshapePreset.cs" },
            new[] { "cafd07912d076b2048046a48e33c9053213147b9db2dd7193161132261aa50cf" }, (97, 98)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsCameraPreset",
            new[] { "Editor", "Presets", "PumkinsCameraPreset.cs" },
            new[] { "d51124f60483c4849bb830b56ee9cd84bde3df24ac8cf50b6e325e9035c577b8" }, (419, 420)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsPosePreset",
            new[] { "Editor", "Presets", "PumkinsPosePreset.cs" },
            new[] { "e424d88028845ce994f1eda58491583da7637b6aa2f2a0310427f2b2cb1b9d13" }, (243, 244)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsPresetManager",
            new[] { "Editor", "Presets", "PumkinsPresetManager.cs" },
            new[] { "25678f0b975fe0b37ef1b324b9919a2e8db9ed6f56861984dc6a6e99ca4d4614" }, (405, 406)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsAvatarTools",
            new[] { "Editor", "PumkinsAvatarTools.cs" },
            new[] { "55f7234e85f158d186fa427a72ea2019a5018a1712541ecf0594e7fe4f50ddff" }, (1592, 1593)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsAvatarTools_MainFunctions",
            new[] { "Editor", "PumkinsAvatarTools_MainFunctions.cs" },
            new[] { "689ac103db37c37f447f1a9e1e5b7cd8e345f148f4220b64f286505aa190851c" }, (1073, 1074)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsAvatarTools_UI",
            new[] { "Editor", "PumkinsAvatarTools_UI.cs" },
            new[] { "bae12e53d5e7628efa730e6a77aec31c52c4ebb502a97ea9c8af2e4996657bca" }, (3058, 3059)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsAvatarTools_UtilityFunctions",
            new[] { "Editor", "PumkinsAvatarTools_UtilityFunctions.cs" },
            new[] { "257417550ac42e12c44e622c9b700ed82fa02dd2541fa5fb4ade5acdebd867f0" }, (489, 490)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsCompileErrorListener",
            new[] { "Editor", "PumkinsCompileErrorListener.cs" },
            new[] { "cd0146345f5960b98844ce6d9f605b7d0cb75c0ee3bd17ddc06c09b3b8edd5d0" }, (41, 42)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsPoseEditor",
            new[] { "Editor", "PumkinsPoseEditor.cs" },
            new[] { "577ce28b5e002fc405ee0683e2ef5578d685c251bc6cadf9dafa91aec0f04ae1" }, (609, 610)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsPoseEditorUtils",
            new[] { "Editor", "PumkinsPoseEditorUtils.cs" },
            new[] { "cf39b0313aea0f11fd4949b30b4939eabb27a1ec45ff69fe05bcba75734a41e1" }, (77, 78)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinToolsLogger",
            new[] { "Editor", "PumkinToolsLogger.cs" },
            new[] { "217d66566a0399be2b0c4a7136b22e7218607150649595318cf35fd29d6a3389" }, (79, 80)),

        new WhitelistEntry("PumkinsAvatarTools - SettingsContainer",
            new[] { "Editor", "SettingsContainer.cs" },
            new[] { "28f13181049d41ba994be859da688f0677a61779dc6cfec45f57a88238b48b5e" }, (410, 411)),

        new WhitelistEntry("PumkinsAvatarTools - SingletonScriptableObject",
            new[] { "Editor", "SingletonScriptableObject.cs" },
            new[] { "a68d433e5bff4e900afdbce138c68f397454fe2df567198281af45df3818ed9d" }, (26, 27)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsTexturePackerEditor",
            new[] { "Editor", "Texture Packer", "PumkinsTexturePackerEditor.cs" },
            new[] { "613bfa37fe56a1d13ab119f0f653db0456823461d1e890b7470bdcf8b233276c" }, (411, 412)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsTexturePackerHelpers",
            new[] { "Editor", "Texture Packer", "PumkinsTexturePackerHelpers.cs" },
            new[] { "00c91a14aafd9d1b21a266ecc0d14098cb796efaaf67eeaf5452055ac6b2dfd7" }, (251, 252)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinTool",
            new[] { "Editor", "Tools", "PumkinTool.cs" },
            new[] { "015ad9fe28bd3b6ad90615a7782928f11bcc99ce6f164124388a118bab04f518" }, (74, 75)),

        new WhitelistEntry("PumkinsAvatarTools - RecalculateBoundsTool",
            new[] { "Editor", "Tools", "RecalculateBoundsTool.cs" },
            new[] { "a8587dbe908a560b7cc84b54c30e1c6acdb565445d0f66c9541514afe8694ed6" }, (91, 92)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsLanguageManager",
            new[] { "Editor", "Translations", "PumkinsLanguageManager.cs" },
            new[] { "970b73b8d8f0dfdc7d575bb81fe26c0bce0264c9d0ee571165eaaf96df287b17" }, (244, 245)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsTranslation",
            new[] { "Editor", "Translations", "PumkinsTranslation.cs" },
            new[] { "592fccfb1d62ff8eadad74a80702b33aa365974df2a745b87fed4b04834c2e61" }, (559, 560)),

        new WhitelistEntry("PumkinsAvatarTools - PumkinsYAMLTools",
            new[] { "Editor", "Translations", "PumkinsYAMLTools.cs" },
            new[] { "18c861fcb798702802b094d4396fd2db76238281fd3e09eed14992cbbbd045be" }, (75, 76)),



        // == GoGoLoco ====================================================
        // SHA-256 verified whitelist entries. Computed from known-good package.

        new WhitelistEntry("GoGoLoco - GoGoLocoLink",
            new[] { "Packages", "gogoloco", "Editor", "GoGoLocoLink.cs" },
            new[] { "b33f0ef1efc796720ab6b0bc8f3225a74f228e88c1b88c069b1827447c0b17b2" }, (20, 21)),

        new WhitelistEntry("GoGoLoco - GoGoLocoMenu",
            new[] { "Packages", "gogoloco", "Editor", "GoGoLocoMenu.cs" },
            new[] { "0cb10885a04c63d30c3fb6c4f8d777139cfe25d47c45ab4c70fbb2f884124a99" }, (124, 125)),



    };
}

