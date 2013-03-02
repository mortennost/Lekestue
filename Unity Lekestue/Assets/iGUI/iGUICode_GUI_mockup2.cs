using UnityEngine;
using System.Collections;
using iGUI;

public class iGUICode_GUI_mockup2 : MonoBehaviour
{
	[HideInInspector]
	public iGUIImage image1;
	[HideInInspector]
	public iGUIRoot root;
	
	#region HUD
	[HideInInspector]
	public iGUIContainer _containerHUD;
	[HideInInspector]
	public iGUIButton _btnOptions;
	[HideInInspector]
	public iGUIButton _btnOpenShop;
	[HideInInspector]
	public iGUIButton _btnPlaceBuilding;
	[HideInInspector]
	public iGUIButton _btnCancelBuilding;
	[HideInInspector]
	public iGUIButton _btnDestroyStructure;
	[HideInInspector]
	public iGUIButton _btnHarvest;
	[HideInInspector]
	public iGUIButton _btnSpawnCreep;
	[HideInInspector]
	public iGUILabel _lblNotification;
	
	#region XP-Bar
	[HideInInspector]
	public iGUIContainer _containerXP;
	[HideInInspector]
	public iGUIImage _imgXPBackground;
	[HideInInspector]
	public iGUIImage _imgXPForeground;
	[HideInInspector]
	public iGUIContainer _containerFillColor;
	[HideInInspector]
	public iGUIImage _imgXPFillColor;
	[HideInInspector]
	public iGUILabel _lblXPLevel;
	#endregion
	
	#region ResourceLabels
	[HideInInspector]
	public iGUIContainer _containerResources;
	[HideInInspector]
	public iGUILabel _lblFood;
	[HideInInspector]
	public iGUILabel _lblWater;
	[HideInInspector]
	public iGUILabel _lblScrap;
	[HideInInspector]
	public iGUILabel _lblWorkers;
	[HideInInspector]
	public iGUIImage _imgFoodIcon;
	[HideInInspector]
	public iGUIImage _imgWaterIcon;
	[HideInInspector]
	public iGUIImage _imgScrapIcon;
	#endregion
	
	#region TrapPanel
	[HideInInspector]
	public iGUIPanel _panelTraps;
	[HideInInspector]
	public iGUIButton _btnUseElectricTrap;
	[HideInInspector]
	public iGUIButton _btnUseMineTrap;
	[HideInInspector]
	public iGUIButton _btnUseControlTrap;
	#endregion
	
	#endregion
	
	#region ShopMenu
	[HideInInspector]
	public iGUIPanel _panelShop;
	[HideInInspector]
	public iGUIButton _btnCloseShop;
	
	#region CategoryView
	[HideInInspector]
	public iGUIContainer _containerShopCategories;
	[HideInInspector]
	public iGUIButton _btnTurretsCategory;
	[HideInInspector]
	public iGUIButton _btnHarvestersCategory;
	[HideInInspector]
	public iGUIButton _btnUtilityCategory;
	[HideInInspector]
	public iGUIButton _btnRealMoneyCategory;
	#endregion
	
	#region TurretsCategory
	[HideInInspector]
	public iGUIScrollView _scrlTurrets;
	[HideInInspector]
	public iGUIButton _btnCrossbowTurret;
	[HideInInspector]
	public iGUIButton _btnFlamethrowerTurret;
	[HideInInspector]
	public iGUIButton _btnFreezerTurret;
	[HideInInspector]
	public iGUIButton _btnScarecrowTurret;
	#endregion
	
	#region HarvestersCategory
	[HideInInspector]
	public iGUIScrollView _scrlHarvesters;
	[HideInInspector]
	public iGUIButton _btnWellHarvester;
	[HideInInspector]
	public iGUIButton _btnRainHarvester;
	[HideInInspector]
	public iGUIButton _btnChickenHarvester;
	[HideInInspector]
	public iGUIButton _btnFieldHarvester;
	#endregion
	
	#region UtilityCategory
	[HideInInspector]
	public iGUIScrollView _scrlUtility;
	[HideInInspector]
	public iGUIButton _btnWorkshedUtility;
	#endregion
	
	#endregion
	
	#region OptionsMenu
	[HideInInspector]
	public iGUIPanel _panelOptions;
	[HideInInspector]
	public iGUIButton _btnExitOptions;
	[HideInInspector]
	public iGUILabel _lblOptionsHeader;
	[HideInInspector]
	public iGUIIntHorizontalSlider _sliderVolume;
	[HideInInspector]
	public iGUIButton _btnCredits;
	#endregion

	static iGUICode_GUI_mockup2 instance;
	
	void Awake()
	{
		instance=this;
	}
	public static iGUICode_GUI_mockup2 getInstance()
	{
		return instance;
	}
}