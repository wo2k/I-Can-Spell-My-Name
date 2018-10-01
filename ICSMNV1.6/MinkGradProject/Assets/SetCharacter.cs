using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class SetCharacter : MonoBehaviour {
	public List<Sprite> Fish;
    public List<Sprite> Jellyfish;
	public List<Sprite> Star;
	public List<Sprite> Urchin;
	public List<Sprite> Angel;
	public List<Sprite> Shark;
    public List<Sprite> Whale;
	public GameObject GameManager;
	public int color;
	public int vari;
	public int chara;
	// Use this for initialization
	void Start () {

        GameManager = FindObjectOfType<LevelManager>().gameObject;
	}

	public void SetUp () {

		switch (GameManager.GetComponent<FirstPlayButtons> ().LoginNumber) {
		case 1:
			{
				color =	PlayerPrefs.GetInt ("firstColor");
				chara = PlayerPrefs.GetInt ("firstCharacter");
				vari = PlayerPrefs.GetInt ("firstVar");
				break;
			}
		case 2:
			{
				color = PlayerPrefs.GetInt ("secondColor");
				chara = PlayerPrefs.GetInt ("secondCharacter");
				vari = PlayerPrefs.GetInt ("secondVar");
				break;
			}
		case 3:
			{
				color = PlayerPrefs.GetInt ("thirdColor");
				chara = PlayerPrefs.GetInt ("thirdCharacter");
				vari = PlayerPrefs.GetInt ("thirdVar");
				break;
			}
		case 4:
			{
				color = PlayerPrefs.GetInt ("fourthColor");
				chara = PlayerPrefs.GetInt ("fourthCharacter");
				vari = PlayerPrefs.GetInt ("fourthVar");
				break;
			}
		}

		switch (color) {
		case 1:
			{
				this.GetComponent<Image> ().color = Color.red;
				break;
			}
		case 2:
			{
				this.GetComponent<Image> ().color = Color.green;
				break;
			}
		case 3:
			{
				this.GetComponent<Image> ().color = new Color (1.0F, (206.0F / 255.0F), 0, 1);
				break;
			}
		case 4:
			{
				this.GetComponent<Image> ().color = Color.cyan;
				break;
			}
		case 5:
			{
				this.GetComponent<Image> ().color = Color.magenta;
				break;
			}
		}

		switch (chara) {
		case 1:
			{
				switch (vari) {
				case 1:
					{
						this.GetComponent<Image> ().sprite = Fish[0];
						break;
					}
				case 2:
					{
						this.GetComponent<Image> ().sprite = Fish[1];
						break;
					}
				case 3:
					{
						this.GetComponent<Image> ().sprite = Fish[2];
						break;
					
					}
				case 4:
					{
						this.GetComponent<Image> ().sprite = Fish[3];
						break;
					}
				case 5:
					{
						this.GetComponent<Image> ().sprite = Fish[4];
						break;
					}
				case 6:
					{
						this.GetComponent<Image> ().sprite = Fish[5];
						break;
					}
				}

				break;
			}
		case 2:
			{
				switch (vari) {
				case 1:
					{
						this.GetComponent<Image> ().sprite = Jellyfish[0];
						break;
					}
				case 2:
					{
						this.GetComponent<Image> ().sprite = Jellyfish[1];
						break;
					}
				case 3:
					{
						this.GetComponent<Image> ().sprite = Jellyfish[2];
						break;

					}
				case 4:
					{
						this.GetComponent<Image> ().sprite = Jellyfish[3];
						break;
					}
				case 5:
					{
						this.GetComponent<Image> ().sprite = Jellyfish[4];
						break;
					}
				case 6:
					{
						this.GetComponent<Image> ().sprite = Jellyfish[5];
						break;
					}
				}

				break;
			}
		case 3:
			{
				switch (vari) {
				case 1:
					{
						this.GetComponent<Image> ().sprite = Star [0];
						break;
					}
				case 2:
					{
						this.GetComponent<Image> ().sprite = Star[1];
						break;
					}
				case 3:
					{
						this.GetComponent<Image> ().sprite = Star[2];
						break;

					}
				case 4:
					{
						this.GetComponent<Image> ().sprite = Star[3];
						break;
					}
				case 5:
					{
						this.GetComponent<Image> ().sprite = Star[4];
						break;
					}
				case 6:
					{
						this.GetComponent<Image> ().sprite = Star[5];
						break;
					}
				}

				break;
			}
		case 4:
			{
				switch (vari) {
				case 1:
					{
						this.GetComponent<Image> ().sprite = Urchin[0];
						break;
					}
				case 2:
					{
						this.GetComponent<Image> ().sprite = Urchin[1];
						break;
					}
				case 3:
					{
						this.GetComponent<Image> ().sprite = Urchin[2];
						break;

					}
				case 4:
					{
						this.GetComponent<Image> ().sprite = Urchin[3];
						break;
					}
				case 5:
					{
						this.GetComponent<Image> ().sprite = Urchin[4];
						break;
					}
				case 6:
					{
						this.GetComponent<Image> ().sprite = Urchin[5];
						break;
					}
				}

				break;
			}
		case 5:
			{
				switch (vari) {
				case 1:
					{
						this.GetComponent<Image> ().sprite = Angel [0];
						break;
					}
				case 2:
					{
						this.GetComponent<Image> ().sprite = Angel[1];
						break;
					}
				case 3:
					{
						this.GetComponent<Image> ().sprite = Angel[2];
						break;

					}
				case 4:
					{
						this.GetComponent<Image> ().sprite = Angel[3];
						break;
					}
				case 5:
					{
						this.GetComponent<Image> ().sprite = Angel[4];
						break;
					}
				case 6:
					{
						this.GetComponent<Image> ().sprite = Angel[5];
						break;
					}
				}

				break;
			}
            case 6:
                {
                    switch (vari)
                    {
                        case 1:
                            {
                                this.GetComponent<Image>().sprite = Shark[0];
                                break;
                            }
                        case 2:
                            {
                                this.GetComponent<Image>().sprite = Shark[1];
                                break;
                            }
                        case 3:
                            {
                                this.GetComponent<Image>().sprite = Shark[2];
                                break;

                            }
                        case 4:
                            {
                                this.GetComponent<Image>().sprite = Shark[3];
                                break;
                            }
                        case 5:
                            {
                                this.GetComponent<Image>().sprite = Shark[4];
                                break;
                            }
                        case 6:
                            {
                                this.GetComponent<Image>().sprite = Shark[5];
                                break;
                            }
                    }

                    break;
                }
            case 7:
                {
                    switch (vari)
                    {
                        case 1:
                            {
                                this.GetComponent<Image>().sprite = Whale[0];
                                break;
                            }
                        case 2:
                            {
                                this.GetComponent<Image>().sprite = Whale[1];
                                break;
                            }
                        case 3:
                            {
                                this.GetComponent<Image>().sprite = Whale[2];
                                break;

                            }
                        case 4:
                            {
                                this.GetComponent<Image>().sprite = Whale[3];
                                break;
                            }
                        case 5:
                            {
                                this.GetComponent<Image>().sprite = Whale[4];
                                break;
                            }
                        case 6:
                            {
                                this.GetComponent<Image>().sprite = Whale[5];
                                break;
                            }
                    }

                    break;
                }
        }


	}
	public void SetUpLogin (int LoginNumber) {

		switch (LoginNumber) {
		case 1:
			{
				color =	PlayerPrefs.GetInt ("firstColor");
				chara = PlayerPrefs.GetInt ("firstCharacter");
				vari = PlayerPrefs.GetInt ("firstVar");
				break;
			}
		case 2:
			{
				color = PlayerPrefs.GetInt ("secondColor");
				chara = PlayerPrefs.GetInt ("secondCharacter");
				vari = PlayerPrefs.GetInt ("secondVar");
				break;
			}
		case 3:
			{
				color = PlayerPrefs.GetInt ("thirdColor");
				chara = PlayerPrefs.GetInt ("thirdCharacter");
				vari = PlayerPrefs.GetInt ("thirdVar");
				break;
			}
		case 4:
			{
				color = PlayerPrefs.GetInt ("fourthColor");
				chara = PlayerPrefs.GetInt ("fourthCharacter");
				vari = PlayerPrefs.GetInt ("fourthVar");
				break;
			}
		}

		switch (color) {
		case 1:
			{
				this.GetComponent<Image> ().color = Color.red;
				break;
			}
		case 2:
			{
				this.GetComponent<Image> ().color = Color.green;
				break;
			}
		case 3:
			{
				this.GetComponent<Image> ().color = new Color (1.0F, (206.0F / 255.0F), 0, 1);
				break;
			}
		case 4:
			{
				this.GetComponent<Image> ().color = Color.cyan;
				break;
			}
		case 5:
			{
				this.GetComponent<Image> ().color = Color.magenta;
				break;
			}
		}

		switch (chara) {
		case 1:
			{
				switch (vari) {
				case 1:
					{
						this.GetComponent<Image> ().sprite = Fish [0];
						break;
					}
				case 2:
					{
						this.GetComponent<Image> ().sprite = Fish [1];
						break;
					}
				case 3:
					{
						this.GetComponent<Image> ().sprite = Fish [2];
						break;

					}
				case 4:
					{
						this.GetComponent<Image> ().sprite = Fish [3];
						break;
					}
				case 5:
					{
						this.GetComponent<Image> ().sprite = Fish [4];
						break;
					}
				case 6:
					{
						this.GetComponent<Image> ().sprite = Fish [5];
						break;
					}
				}

				break;
			}
		case 2:
			{
				switch (vari) {
				case 1:
					{
						this.GetComponent<Image> ().sprite = Jellyfish [0];
						break;
					}
				case 2:
					{
						this.GetComponent<Image> ().sprite = Jellyfish[1];
						break;
					}
				case 3:
					{
						this.GetComponent<Image> ().sprite = Jellyfish[2];
						break;

					}
				case 4:
					{
						this.GetComponent<Image> ().sprite = Jellyfish[3];
						break;
					}
				case 5:
					{
						this.GetComponent<Image> ().sprite = Jellyfish[4];
						break;
					}
				case 6:
					{
						this.GetComponent<Image> ().sprite = Jellyfish[5];
						break;
					}
				}

				break;
			}
		case 3:
			{
				switch (vari) {
				case 1:
					{
						this.GetComponent<Image> ().sprite = Star [0];
						break;
					}
				case 2:
					{
						this.GetComponent<Image> ().sprite = Star[1];
						break;
					}
				case 3:
					{
						this.GetComponent<Image> ().sprite = Star[2];
						break;

					}
				case 4:
					{
						this.GetComponent<Image> ().sprite = Star[3];
						break;
					}
				case 5:
					{
						this.GetComponent<Image> ().sprite = Star[4];
						break;
					}
				case 6:
					{
						this.GetComponent<Image> ().sprite = Star[5];
						break;
					}
				}

				break;
			}
		case 4:
			{
				switch (vari) {
				case 1:
					{
						this.GetComponent<Image> ().sprite = Urchin [0];
						break;
					}
				case 2:
					{
						this.GetComponent<Image> ().sprite = Urchin[1];
						break;
					}
				case 3:
					{
						this.GetComponent<Image> ().sprite = Urchin[2];
						break;

					}
				case 4:
					{
						this.GetComponent<Image> ().sprite = Urchin[3];
						break;
					}
				case 5:
					{
						this.GetComponent<Image> ().sprite = Urchin[4];
						break;
					}
				case 6:
					{
						this.GetComponent<Image> ().sprite = Urchin[5];
						break;
					}
				}

				break;
			}
		case 5:
			{
				switch (vari) {
				case 1:
					{
						this.GetComponent<Image> ().sprite = Angel [0];
						break;
					}
				case 2:
					{
						this.GetComponent<Image> ().sprite = Angel[1];
						break;
					}
				case 3:
					{
						this.GetComponent<Image> ().sprite = Angel[2];
						break;

					}
				case 4:
					{
						this.GetComponent<Image> ().sprite = Angel[3];
						break;
					}
				case 5:
					{
						this.GetComponent<Image> ().sprite = Angel[4];
						break;
					}
				case 6:
					{
						this.GetComponent<Image> ().sprite = Angel[5];
						break;
					}
				}

				break;
			}

            case 6:
                {
                    switch (vari)
                    {
                        case 1:
                            {
                                this.GetComponent<Image>().sprite = Shark[0];
                                break;
                            }
                        case 2:
                            {
                                this.GetComponent<Image>().sprite = Shark[1];
                                break;
                            }
                        case 3:
                            {
                                this.GetComponent<Image>().sprite = Shark[2];
                                break;

                            }
                        case 4:
                            {
                                this.GetComponent<Image>().sprite = Shark[3];
                                break;
                            }
                        case 5:
                            {
                                this.GetComponent<Image>().sprite = Shark[4];
                                break;
                            }
                        case 6:
                            {
                                this.GetComponent<Image>().sprite = Shark[5];
                                break;
                            }
                    }

                    break;
                }

            case 7:
                {
                    switch (vari)
                    {
                        case 1:
                            {
                                this.GetComponent<Image>().sprite = Whale[0];
                                break;
                            }
                        case 2:
                            {
                                this.GetComponent<Image>().sprite = Whale[1];
                                break;
                            }
                        case 3:
                            {
                                this.GetComponent<Image>().sprite = Whale[2];
                                break;

                            }
                        case 4:
                            {
                                this.GetComponent<Image>().sprite = Whale[3];
                                break;
                            }
                        case 5:
                            {
                                this.GetComponent<Image>().sprite = Whale[4];
                                break;
                            }
                        case 6:
                            {
                                this.GetComponent<Image>().sprite = Whale[5];
                                break;
                            }
                    }

                    break;
                }
        }


	}
	
	// Update is called once per frame
	void Update () {
		SetUp ();
	}
}
