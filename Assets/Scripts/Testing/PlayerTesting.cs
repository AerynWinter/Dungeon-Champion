using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class PlayerTesting {

	[Test]
	public void testPlayerGetMaxHealth () {
		PlayerData p = new PlayerData();

		// Create stats array
		p.stats = new int[6];

		// At 1 point in constitution the player should have 100 + 2 hp
		p.stats [(int)GameControl.playerStats.Constitution] = 1;
		Assert.AreEqual(102, p.getMaxHealth());

		// At 5 points in con, the player should have 100 + 10 hp
		p.stats [(int)GameControl.playerStats.Constitution] = 5;
		Assert.AreEqual (110, p.getMaxHealth ());

		// At 20 points in con, the player should have 100 + 40 hp
		p.stats [(int)GameControl.playerStats.Constitution] = 20;
		Assert.AreEqual (140, p.getMaxHealth ());
	}

	[Test]
	public void testCorrectLevelForExperience () {
		PlayerData p = new PlayerData ();

		// 0 exp = lvl 1
		p.experience = 0;
		Assert.AreEqual (1, p.getLevelForExperience (0));
		Assert.AreEqual (1, p.refreshLevel ());

		// 50 exp = lvl 2
		p.experience = 50;
		p.level = 1;
		Assert.AreEqual (50, p.getExperienceForNextLevel ());
		Assert.AreEqual (2, p.getLevelForExperience (50));
		Assert.AreEqual (2, p.refreshLevel ());

		// 800 exp = lvl 5
		p.experience = 800;
		p.level = 4;
		Assert.AreEqual (800, p.getExperienceForNextLevel ());
		Assert.AreEqual (5, p.getLevelForExperience (800));
		Assert.AreEqual (5, p.refreshLevel ());

		// 18050 exp = lvl 20
		p.experience = 18050;
		p.level = 19;
		Assert.AreEqual (18050, p.getExperienceForNextLevel ());
		Assert.AreEqual (20, p.getLevelForExperience (18050));
		Assert.AreEqual (20, p.refreshLevel ());

		// 76050 exp = lvl 40
		p.experience = 76050;
		p.level = 39;
		Assert.AreEqual (76050, p.getExperienceForNextLevel ());
		Assert.AreEqual (40, p.getLevelForExperience (76050));
		Assert.AreEqual (40, p.refreshLevel ());
	}
}
