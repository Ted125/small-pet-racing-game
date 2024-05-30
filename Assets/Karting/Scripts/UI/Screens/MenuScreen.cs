using KartGame.KartSystems;
using Karting.Config;
using Karting.Data;
using Karting.UI.Core;
using Karting.UI.Popups;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Karting.UI.Screens
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text _playerName;
        [SerializeField] private Button _raceButton;
        [SerializeField] private Button _leaderboardButton;
        [SerializeField] private TMP_Text _coinText;
        public GameObject cartTurnTableModel;
        public int currentTurntableCartID;
        public int currentSelectedCartID;

        [SerializeField] Transform spawnCartParent;

        private void Start()
        {

            //PlayerPrefs.DeleteAll();
            _leaderboardButton.onClick.AddListener(ShowLeaderboardPopup);
            _raceButton.onClick.AddListener(LoadRaceScene);
            DisplayPlayerName();
            ShowWelcomePopup();
            SaveData.OnPlayerNameUpdated += DisplayPlayerName;
            currentSelectedCartID = PlayerPrefs.GetInt("CART_ID", 0);
            currentTurntableCartID = -1;
            ChangeCart(currentSelectedCartID);
            UpdateCoins();

        }

        public void UpdateCoins()
        {
            _coinText.text = PlayerPrefs.GetInt("coins", 0).ToString();
        }

        public void ChangeCart(int id)
        {
            if (id == currentTurntableCartID)
                return;

            if (cartTurnTableModel != null)
                Destroy(cartTurnTableModel);

            currentTurntableCartID = id;
            SpawnCart(id);

        }

        GameObject SpawnCart(int id)
        {
            CartData data = CartDataManager.GetInstance().carts[id];
            currentTurntableCartID = id;

            GameObject GoCart = Instantiate(Resources.Load<GameObject>("carts/" + data.prefabName),
                spawnCartParent) as GameObject;
            GoCart.GetComponent<ArcadeKart>().Customize(data);
            SetGameLayerRecursive(GoCart, 13);
            GoCart.GetComponent<Rigidbody>().isKinematic = true;
            GoCart.GetComponent<Rigidbody>().useGravity = false;
            cartTurnTableModel = GoCart;
            return GoCart;
        }


        private void SetGameLayerRecursive(GameObject _go, int _layer)
        {
            _go.layer = _layer;
            foreach (Transform child in _go.transform)
            {
                child.gameObject.layer = _layer;

                Transform _HasChildren = child.GetComponentInChildren<Transform>();
                if (_HasChildren != null)
                    SetGameLayerRecursive(child.gameObject, _layer);

            }
        }

        private void ShowWelcomePopup()
        {
            var saveData = SaveData.Load();

            if (!saveData.HasPlayerRenamed)
            {
                UIManager.Instance.ShowPopup<WelcomePopup>();
            }
        }

        private void DisplayPlayerName()
        {
            var saveData = SaveData.Load();
            _playerName.text = saveData.PlayerName;
        }

        private void ShowLeaderboardPopup()
        {
            UIManager.Instance.ShowPopup<LeaderboardPopup>();
        }

        private void LoadRaceScene()
        {
            var saveData = SaveData.Load();
            var energyCost = ConfigManager.Instance.EnergyConfig.RaceEnergyCost;

            if (saveData.RemainingEnergy < energyCost)
            {
                return;
            }

            saveData.ConsumeEnergy(energyCost);
            SceneManager.LoadScene("MainScene");
        }
    }
}