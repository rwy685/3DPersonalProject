# 프로젝트 이름 3DPersonalProject

## 📖 목차
1. [프로젝트 소개](#프로젝트-소개)
2. [주요기능](#주요기능)
3. [개발기간](#개발기간)
4. [기술스택](#기술스택)
6. [프로젝트 파일 구조](#프로젝트-파일-구조)
7. [Trouble Shooting](#trouble-shooting)


## 👨‍🏫 프로젝트 소개
- 프로젝트 명 : 3DPersonalProject
- 프로젝트 설명 : 플레이어의 스탯과 아이템/인벤토리를 구현해보고 데이터를 다루는 과정을 다룹니다. 
- 프로젝트 시작 계기 : 심화과제로 발제된 인벤토리 기능 만들기를 참고했습니다.
- 프로젝트 구성 인원 : 유원영


## 💜 주요기능

-GameManager : 전역 매니저 및 신 전용 매니저 생성 및 관리를 담당합니다.

-Charactermanager : 플레이어 프리펩을 생성하고, 전역으로 관리합니다.

-UIManager : MainScene 전용 UI패널들을 스택으로 관리합니다.

-HUDManager : Player의 전역 HUDUI를 관리합니다.

-EquipmentManager : Inventory에 있는 아이템을 장착/해제 기능을 처리합니다.

-DataManager : 플레이어/아이템/인벤토리/장착 여부를 JSON화 해서 저장/로드 합니다.

-itemInfo(Loader) : ItemInfo를 Json에서 데이터로 변환합니다.

-OptionInfo(Loader) : ItemInfo에 적용될 Option을 Json에서 데이터로 변환합니다. 


<img width="751" height="462" alt="Image" src="https://github.com/user-attachments/assets/a4a9e73e-a59d-497e-bf6e-439b4b489b23" />


<img width="756" height="465" alt="Image" src="https://github.com/user-attachments/assets/e98f9745-47ad-4922-9e9a-88d804650171" />



## ⏲️ 개발기간
- 총 5일   { 2025.11.24(월) ~ 2025.11.28(금) }


## 🔧 기술스택

### 외부 툴

* ExcelToJsonWizard

###  Language
*  C#

###  Version Control
*  Git + GitHubDesktop + Fork

###  IDE
* Visual Studio

###  Framework
* net9.0


### 🚀 배포 (Deploy)
- **빌드 환경:** Unity 2022.3.62f2
- **배포 방식:** 
- **결과물:** 


## 프로젝트 파일 구조

Assets
 ┃
 ┃
 ┣ 📂02_Scripts
 ┃ ┣ 📂Generated // Excel->Json->C# 데이터 변환용 및 Enum
 ┃ ┃ ┣ DesignEnums.cs
 ┃ ┃ ┣ ItemInfo.cs
 ┃ ┃ ┗  OptionInfo.cs
 ┃ ┣ 📂Item // 아이템 관련 및 아이템데이터저장 
 ┃ ┃ ┣ ItemInstance.cs
 ┃ ┃ ┣ ItemOptionValue.cs
 ┃ ┃ ┗  SaveData.cs
 ┃ ┣ 📂Player // 플레이어 스탯 및 인벤토리 관련
 ┃ ┃ ┣ Inventory.cs
 ┃ ┃ ┣ Player.cs
 ┃ ┃ ┣ PlayerCondition.cs
 ┃ ┃ ┣ PlayerController.cs
 ┃ ┃ ┣ PlayerStatus.cs
 ┃ ┃ ┗ PlayerStatusData.cs
 ┃ ┣ 📂Save_Load // 저장/로드 버튼
 ┃ ┃ ┣ LoadButton.cs
 ┃ ┃ ┗ SaveButton.cs
 ┃ ┣ 📂UI // UI관련 기능
 ┃ ┃ ┣ 📂Inventory
 ┃ ┃ ┃ ┣ InventorySlotUI.cs
 ┃ ┃ ┃ ┣ InventoryTabButtons.cs
 ┃ ┃ ┃ ┣ InventoryUI.cs
 ┃ ┃ ┃ ┗ ItemPopUpUI.cs
 ┃ ┃ ┣📂 PlayerHUD //플레이어 HUD UI 관련 기능
 ┃ ┃ ┃ ┣ GoldUI.cs
 ┃ ┃ ┃ ┗ PlayerHUDUI.cs
 ┃ ┃ ┣ 📂Status // 플레이어 스탯 UI 관련 기능
 ┃ ┃ ┃ ┗ PlayerStatusUI.cs
 ┃ ┃ ┣ Buttons.cs
 ┃ ┃ ┗ Inventory.meta
 ┣ 📂03_Managers // 매니저 스크립트 모음
 ┃ ┣ CharacterManager.cs
 ┃ ┣ DataManager.cs
 ┃ ┣ EquipmentManager.cs
 ┃ ┣ GameManager.cs
 ┃ ┣ HUDManager.cs
 ┗ ┗ UIManager.cs


## Trouble-shooting

1. Grid Layout 오류
https://anuzik.tistory.com/50
