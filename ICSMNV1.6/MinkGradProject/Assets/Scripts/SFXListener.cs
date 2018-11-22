using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SFXListener : MonoBehaviour {
	AudioSource MyAudio;
	private UnityAction A;
	private UnityAction B;
	private UnityAction C;
	private UnityAction D;
	private UnityAction E;
	private UnityAction F;
	private UnityAction G;
	private UnityAction H;
	private UnityAction I;
	private UnityAction J;
	private UnityAction K;
	private UnityAction L;
	private UnityAction M;
	private UnityAction N;
	private UnityAction O;
	private UnityAction P;
	private UnityAction Q;
	private UnityAction R;
	private UnityAction S;
	private UnityAction T;
	private UnityAction U;
	private UnityAction V;
	private UnityAction W;
	private UnityAction X;
	private UnityAction Y;
	private UnityAction Z;

	private UnityAction SeagullAmb;
	private UnityAction BellAmb;
	private UnityAction BoatCreek;
	private UnityAction CannonShot;
	private UnityAction CannonMiss;
	private UnityAction ChestClose;
	private UnityAction ChestCloser;
	private UnityAction ChestOpen;
	private UnityAction DolphinCry;
	private UnityAction HeartLost;
	private UnityAction Motor;
	private UnityAction Pop;
	private UnityAction SeagullCaw;
	private UnityAction SeagullAmb2;
	private UnityAction BoatCreek2;
	private UnityAction SuctionCup;
	private UnityAction WindHowl;
    private UnityAction CorrectAnswer;
    private UnityAction LevelComplete;
    private UnityAction WrongAnswer;
    private UnityAction ClockLoop;
    private UnityAction LoudClock;
    private UnityAction TimeRunningOut;
    private UnityAction Bubbles01;
    private UnityAction CannonHit;

	public List<AudioClip> A_Sounds;
	public List<AudioClip> B_Sounds;
	public List<AudioClip> C_Sounds;
	public List<AudioClip> D_Sounds;
	public List<AudioClip> E_Sounds;
	public List<AudioClip> F_Sounds;
	public List<AudioClip> G_Sounds;
	public List<AudioClip> H_Sounds;
	public List<AudioClip> I_Sounds;
	public List<AudioClip> J_Sounds;
	public List<AudioClip> K_Sounds;
	public List<AudioClip> L_Sounds;
	public List<AudioClip> M_Sounds;
	public List<AudioClip> N_Sounds;
	public List<AudioClip> O_Sounds;
	public List<AudioClip> P_Sounds;
	public List<AudioClip> Q_Sounds;
	public List<AudioClip> R_Sounds;
	public List<AudioClip> S_Sounds;
	public List<AudioClip> T_Sounds;
	public List<AudioClip> U_Sounds;
	public List<AudioClip> V_Sounds;
	public List<AudioClip> W_Sounds;
	public List<AudioClip> X_Sounds;
	public List<AudioClip> Y_Sounds;
	public List<AudioClip> Z_Sounds;

	public List<AudioClip> Effects;

	// Use this for initialization
	void Start () {
		MyAudio = GetComponent<AudioSource>();
	}
	void Awake(){
		A = new UnityAction (PlayA);
		B = new UnityAction (PlayB);
		C = new UnityAction (PlayC);
		D = new UnityAction (PlayD);
		E = new UnityAction (PlayE);
		F = new UnityAction (PlayF);
		G = new UnityAction (PlayG);
		H = new UnityAction (PlayH);
		I = new UnityAction (PlayI);
		J = new UnityAction (PlayJ);
		K = new UnityAction (PlayK);
		L = new UnityAction (PlayL);
		M = new UnityAction (PlayM);
		N = new UnityAction (PlayN);
		O = new UnityAction (PlayO);
		P = new UnityAction (PlayP);
		Q = new UnityAction (PlayQ);
		R = new UnityAction (PlayR);
		S = new UnityAction (PlayS);
		T = new UnityAction (PlayT);
		U = new UnityAction (PlayU);
		V = new UnityAction (PlayV);
		W = new UnityAction (PlayW);
		X = new UnityAction (PlayX);
		Y = new UnityAction (PlayY);
		Z = new UnityAction (PlayZ);

		SeagullAmb = new UnityAction (PlayEffect0);
		BellAmb = new UnityAction (PlayEffect1);
		BoatCreek = new UnityAction (PlayEffect2);
		CannonShot = new UnityAction (PlayEffect3);
		CannonMiss= new UnityAction (PlayEffect4);
        CannonHit = new UnityAction(PlayEffect24);
		ChestClose= new UnityAction (PlayEffect5);
		ChestCloser = new UnityAction (PlayEffect6);
		ChestOpen = new UnityAction (PlayEffect7);
		DolphinCry = new UnityAction (PlayEffect8);
		HeartLost = new UnityAction (PlayEffect9);
		Motor = new UnityAction (PlayEffect10);
		Pop = new UnityAction (PlayEffect11);
		SeagullCaw = new UnityAction (PlayEffect12);
		SeagullAmb2 = new UnityAction (PlayEffect13);
		BoatCreek2 = new UnityAction (PlayEffect14);
		SuctionCup = new UnityAction (PlayEffect15);
		WindHowl = new UnityAction (PlayEffect16);
        CorrectAnswer = new UnityAction (PlayEffect17);
        LevelComplete = new UnityAction (PlayEffect18);
        WrongAnswer = new UnityAction (PlayEffect19);
        ClockLoop = new UnityAction (PlayEffect20);
        LoudClock = new UnityAction (PlayEffect21);
        TimeRunningOut = new UnityAction (PlayEffect22);
        Bubbles01 = new UnityAction(PlayEffect23);
	
	}
	void OnEnable(){
		SoundManagement.Startlistening ("PlayA", A);
		SoundManagement.Startlistening ("PlayB", B);
		SoundManagement.Startlistening ("PlayC", C);
		SoundManagement.Startlistening ("PlayD", D);
		SoundManagement.Startlistening ("PlayE", E);
		SoundManagement.Startlistening ("PlayF", F);
		SoundManagement.Startlistening ("PlayG", G);
		SoundManagement.Startlistening ("PlayH", H);
		SoundManagement.Startlistening ("PlayI", I);
		SoundManagement.Startlistening ("PlayJ", J);
		SoundManagement.Startlistening ("PlayK", K);
		SoundManagement.Startlistening ("PlayL", L);
		SoundManagement.Startlistening ("PlayM", M);
		SoundManagement.Startlistening ("PlayN", N);
		SoundManagement.Startlistening ("PlayO", O);
		SoundManagement.Startlistening ("PlayP", P);
		SoundManagement.Startlistening ("PlayQ", Q);
		SoundManagement.Startlistening ("PlayR", R);
		SoundManagement.Startlistening ("PlayS", S);
		SoundManagement.Startlistening ("PlayT", T);
		SoundManagement.Startlistening ("PlayU", U);
		SoundManagement.Startlistening ("PlayV", V);
		SoundManagement.Startlistening ("PlayW", W);
		SoundManagement.Startlistening ("PlayX", X);
		SoundManagement.Startlistening ("PlayY", Y);
		SoundManagement.Startlistening ("PlayZ", Z);
	
	
		SoundManagement.Startlistening ("PlaySeagullAmb", SeagullAmb);
		SoundManagement.Startlistening ("PlayBellAmb", BellAmb);
		SoundManagement.Startlistening ("PlayBoatCreek", BoatCreek);
		SoundManagement.Startlistening ("PlayCannonShot", CannonShot);
		SoundManagement.Startlistening ("PlayCannonMiss", CannonMiss);
        SoundManagement.Startlistening("PlayCannonHit", CannonHit);
        SoundManagement.Startlistening ("PlayChestClose", ChestClose);
		SoundManagement.Startlistening ("PlayChestCloser", ChestCloser);
		SoundManagement.Startlistening ("PlayChestOpen", ChestOpen);
		SoundManagement.Startlistening ("PlayDolphinCry", DolphinCry);
		SoundManagement.Startlistening ("PlayHeatLost", HeartLost);
		SoundManagement.Startlistening ("PlayMotor", Motor);
		SoundManagement.Startlistening ("PlayPop", Pop);
		SoundManagement.Startlistening ("PlaySeagullCaw", SeagullCaw);
		SoundManagement.Startlistening ("PlaySeagullAmb2", SeagullAmb2);
		SoundManagement.Startlistening ("PlayBoatCreek2", BoatCreek2);
		SoundManagement.Startlistening ("PlaySuctionCup", SuctionCup);
		SoundManagement.Startlistening ("PlayWindHowl", WindHowl);
        SoundManagement.Startlistening ("PlayCorrect", CorrectAnswer);
        SoundManagement.Startlistening ("PlayLevelComplete", LevelComplete);
        SoundManagement.Startlistening ("PlayWrongAnswer", WrongAnswer);
        SoundManagement.Startlistening ("PlayClockLoop", ClockLoop);
        SoundManagement.Startlistening ("PlayLoudClock", LoudClock);
        SoundManagement.Startlistening ("PlayTimeRunningOut", TimeRunningOut);
        SoundManagement.Startlistening ("Bubbles01", Bubbles01);

    }
	void OnDisable(){
		SoundManagement.Stoplistening ("PlayA", A);
		SoundManagement.Stoplistening ("PlayB", B);
		SoundManagement.Stoplistening ("PlayC", C);
		SoundManagement.Stoplistening ("PlayD", D);
		SoundManagement.Stoplistening ("PlayE", E);
		SoundManagement.Stoplistening ("PlayF", F);
		SoundManagement.Stoplistening ("PlayG", G);
		SoundManagement.Stoplistening ("PlayH", H);
		SoundManagement.Stoplistening ("PlayI", I);
		SoundManagement.Stoplistening ("PlayJ", J);
		SoundManagement.Stoplistening ("PlayK", K);
		SoundManagement.Stoplistening ("PlayL", L);
		SoundManagement.Stoplistening ("PlayM", M);
		SoundManagement.Stoplistening ("PlayN", N);
		SoundManagement.Stoplistening ("PlayO", O);
		SoundManagement.Stoplistening ("PlayP", P);
		SoundManagement.Stoplistening ("PlayQ", Q);
		SoundManagement.Stoplistening ("PlayR", R);
		SoundManagement.Stoplistening ("PlayS", S);
		SoundManagement.Stoplistening ("PlayT", T);
		SoundManagement.Stoplistening ("PlayU", U);
		SoundManagement.Stoplistening ("PlayV", V);
		SoundManagement.Stoplistening ("PlayW", W);
		SoundManagement.Stoplistening ("PlayX", X);
		SoundManagement.Stoplistening ("PlayY", Y);
		SoundManagement.Stoplistening ("PlayZ", Z);

		SoundManagement.Stoplistening ("PlaySeagullAmb", SeagullAmb);
		SoundManagement.Stoplistening ("PlayBellAmb", BellAmb);
		SoundManagement.Stoplistening ("PlayBoatCreek", BoatCreek);
		SoundManagement.Stoplistening ("PlayCannonShot", CannonShot);
		SoundManagement.Stoplistening ("PlayCannonMiss", CannonMiss);
        SoundManagement.Stoplistening("PlayCannonHit", CannonHit);
        SoundManagement.Stoplistening ("PlayChestClose", ChestClose);
		SoundManagement.Stoplistening ("PlayChestCloser", ChestCloser);
		SoundManagement.Stoplistening ("PlayChestOpen", ChestOpen);
		SoundManagement.Stoplistening ("PlayDolphinCry", DolphinCry);
		SoundManagement.Stoplistening ("PlayHeatLost", HeartLost);
		SoundManagement.Stoplistening ("PlayMotor", Motor);
		SoundManagement.Stoplistening ("PlayPop", Pop);
		SoundManagement.Stoplistening ("PlaySeagullCaw", SeagullCaw);
		SoundManagement.Stoplistening ("PlaySeagullAmb2", SeagullAmb2);
		SoundManagement.Stoplistening ("PlayBoatCreek2", BoatCreek2);
		SoundManagement.Stoplistening ("PlaySuctionCup", SuctionCup);
		SoundManagement.Stoplistening ("PlayWindHowl", WindHowl);
        SoundManagement.Stoplistening ("PlayCorrect", CorrectAnswer);
        SoundManagement.Stoplistening ("PlayLevelComplete", LevelComplete);
        SoundManagement.Stoplistening ("PlayWrongAnswer", WrongAnswer);
        SoundManagement.Stoplistening ("PlayClockLoop", ClockLoop);
        SoundManagement.Stoplistening ("PlayLoudClock", LoudClock);
        SoundManagement.Stoplistening ("PlayTimeRunningOut", TimeRunningOut);
        SoundManagement.Stoplistening ("Bubbles01", Bubbles01);
    }

	// Update is called once per frame
	void Update () {
		
	}

	void PlayA(){
		int random = Random.Range (0, A_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (A_Sounds [random]);
	}
	void PlayB(){
		int random = Random.Range (0, B_Sounds.Count);

		//if(MyAudio.isPlaying == false)
			MyAudio.PlayOneShot (B_Sounds [random]);
	}
	void PlayC(){
		int random = Random.Range (0, C_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (C_Sounds [random]);
	}
	void PlayD(){
		int random = Random.Range (0, D_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (D_Sounds [random]);
	}
	void PlayE(){
		int random = Random.Range (0, E_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (E_Sounds [random]);
	}
	void PlayF(){
		int random = Random.Range (0, F_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (F_Sounds [random]);
	}
	void PlayG(){
		int random = Random.Range (0, G_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (G_Sounds [random]);
	}
	void PlayH(){
		int random = Random.Range (0, H_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (H_Sounds [random]);
	}
	void PlayI(){
		int random = Random.Range (0, I_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (I_Sounds [random]);
	}
	void PlayJ(){
		int random = Random.Range (0, J_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (J_Sounds [random]);
	}
	void PlayK(){
		int random = Random.Range (0, K_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (K_Sounds [random]);
	}
	void PlayL(){
		int random = Random.Range (0, L_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (L_Sounds [random]);
	}
	void PlayM(){
		int random = Random.Range (0, M_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (M_Sounds [random]);
	}
	void PlayN(){
		int random = Random.Range (0, N_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (N_Sounds [random]);
	}
	void PlayO(){
		int random = Random.Range (0, O_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (O_Sounds [random]);
	}
	void PlayP(){
		int random = Random.Range (0, P_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (P_Sounds [random]);
	}
	void PlayQ(){
		int random = Random.Range (0, Q_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (Q_Sounds [random]);
	}
	void PlayR(){
		int random = Random.Range (0, R_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (R_Sounds [random]);
	}
	void PlayS(){
		int random = Random.Range (0, S_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (S_Sounds [random]);
	}
	void PlayT(){
		int random = Random.Range (0, T_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (T_Sounds [random]);
	}
	void PlayU(){
		int random = Random.Range (0, U_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (U_Sounds [random]);
	}
	void PlayV(){
		int random = Random.Range (0, V_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (V_Sounds [random]);
	}
	void PlayW(){
		int random = Random.Range (0, W_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (W_Sounds [random]);
	}
	void PlayX(){
		int random = Random.Range (0, X_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (X_Sounds [random]);
	}
	void PlayY(){
		int random = Random.Range (0, Y_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (Y_Sounds [random]);
	}
	void PlayZ(){
		int random = Random.Range (0, Z_Sounds.Count);

		//if(MyAudio.isPlaying == false)
		MyAudio.PlayOneShot (Z_Sounds [random]);
	}
	void PlayEffect0(){
		MyAudio.PlayOneShot (Effects [0]);
	}
	void PlayEffect1(){
		MyAudio.PlayOneShot (Effects [1]);
	}
	void PlayEffect2(){
		MyAudio.PlayOneShot (Effects [2]);
	}
	void PlayEffect3(){
		MyAudio.PlayOneShot (Effects [3]);
	}
	void PlayEffect4(){
		MyAudio.PlayOneShot (Effects [4]);
	}
	void PlayEffect5(){
		MyAudio.PlayOneShot (Effects [5]);
	}
	void PlayEffect6(){
		MyAudio.PlayOneShot (Effects [6]);
	}
	void PlayEffect7(){
		MyAudio.PlayOneShot (Effects [7]);
	}
	void PlayEffect8(){
		MyAudio.PlayOneShot (Effects [8]);
	}
	void PlayEffect9(){
		MyAudio.PlayOneShot (Effects [9]);
	}
	void PlayEffect10(){
		MyAudio.PlayOneShot (Effects [10]);
	}
	void PlayEffect11(){
		MyAudio.PlayOneShot (Effects [11]);
	}
	void PlayEffect12(){
		MyAudio.PlayOneShot (Effects [12]);
	}
	void PlayEffect13(){
		MyAudio.PlayOneShot (Effects [13]);
	}
	void PlayEffect14(){
		MyAudio.PlayOneShot (Effects [14]);
	}
	void PlayEffect15(){
		MyAudio.PlayOneShot (Effects [15]);
	}
	void PlayEffect16(){
		MyAudio.PlayOneShot (Effects [16]);
	}
    void PlayEffect17()
    {
        MyAudio.PlayOneShot(Effects[17]);
    }
    void PlayEffect18()
    {
        MyAudio.PlayOneShot(Effects[18]);
    }
    void PlayEffect19()
    {
        MyAudio.PlayOneShot(Effects[19]);
    }
    void PlayEffect20()
    {
        MyAudio.PlayOneShot(Effects[20]);
    }
    void PlayEffect21()
    {
        MyAudio.PlayOneShot(Effects[21]);
    }
    void PlayEffect22()
    {
        MyAudio.PlayOneShot(Effects[22]);
    }
    void PlayEffect23()
    {
        MyAudio.PlayOneShot(Effects[23]);
    }
    void PlayEffect24()
    {
        MyAudio.PlayOneShot(Effects[24]);
    }
}


