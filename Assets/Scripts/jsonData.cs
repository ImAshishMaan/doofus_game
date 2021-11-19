using System;

[Serializable]
public class JsonData {
    public Player_Data player_data;
    public Pulpit_Data pulpit_data;
}
[Serializable]
public class Player_Data {
    public int speed;
}
[Serializable]
public class Pulpit_Data {
    public int min_pulpit_destroy_time;
    public int max_pulpit_destroy_time;
    public float pulpit_spawn_time;
}
