using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NewConductorL : MonoBehaviour
{
    // A reference to the start object
    public GameObject StartObject;

    // A reference to the end object
    public GameObject EndObject;

    // A reference to the prefab we'll use to construct the beat objects
    public GameObject BeatPrefab;

    // How much "play" there is in hitting th beats. E.g. If this value is 0 players have to hit the note exactly,
    // if the value is 1 players.
    [Min(0)]
    public float InputForgiveness = 1;

    // The song. Each beat in the song is represented as an offset in seconds from the start
    private List<float> Song = new List<float>
    {
        //4f,17f,21f,25f,29f,33.5f,37.5f,41.5f,45.5f,49.5f,53.5f,57.5f,61.5f,80.5f,84.5f,88.5f,92.5f,96.5f,98.5f,100.5f,102.5f,104.5f,106.5f,108.5f,110.5f,112.5f,114.5f,116.5f,118.5f,119.75f,121.5f,123.5f,125.5f,127.5f,127.75f
    8f,16.75f,20f,21.5f,24.75f,28f,29.5f,32.75f,34.25f,35f,36.75f,38.25f,39f,40.75f,42.25f,43f,44.75f,46.25f,47f,48.75f,50.25f,51f,52.75f,54.25f,55f,56.75f,58.25f,59f,60.75f,62.25f,63f,80.375f,82f,82.75f,84.375f,86f,86.75f,88.375f,90f,92.375f,94f,94.75f,96.375f,97.125f,98.375f,99.125f,100.375f,101.125f,102.375f,103.125f,104f,104.75f,106f,106.75f,108f,108.75f,110f,110.75f,111.75f,112.125f,112.375f,113.125f,114f,114.25f,114.875f,115.25f,116.125f,116.375f,117.125f,118f,118.25f,118.875f,119.25f,120.125f,120.375f,121.125f,121.5f,122.125f,122.375f,123.125f,124f,124.25f,124.875f,125.25f,126.125f,126.375f,127.125f,128f
    };

    // The interval of the song that is visible. E.g. 5 means you are displaying a 5 second section of the song
    [Min(1)] public float Interval = 5;

    // The current time in the song as seconds since the beginning
    private float _current = 0;

    // The collection of active beats organized by time
    private Dictionary<float, GameObject> _beats = new Dictionary<float, GameObject>();

    private void Update()
    {
        // Update the time
        _current += Time.deltaTime;

        // Update the beats
        UpdateBeats();

        // Listen for the user pressing the space bar to detect "hits"
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            var hitBeats = GetBeatsInRange(InputForgiveness, _current, _beats);
            foreach (var beat in hitBeats)
            {
                // TODO: Do something interesting with the beat
                // Debug.Log("Hit beat!");
                beat.GetComponent<Beat>().OnHit();
            }
        }

        // Listen for the user pressing the R key to reset the song
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }

    private void UpdateBeats()
    {
        // Update the beats

        // Get the spatial bounds
        var startPos = StartObject.transform.position;
        var endPos = EndObject.transform.position;

        // Get the positions for the beats that are currently visible
        var positions = GetBeatPositions(_current, Interval, Song);
        // if there are no positions it means there's no beats to show so clear out any beats and bail out
        if (positions.Count == 0)
        {
            ClearBeats();
            return;
        }

        // Clear any beats that are older than the current time
        var oldBeats = new List<KeyValuePair<float, GameObject>>();
        foreach (var beatEntry in _beats)
        {
            if (beatEntry.Key < _current)
            {
                oldBeats.Add(beatEntry);
            }
        }

        foreach (var oldBeat in oldBeats)
        {
            Destroy(oldBeat.Value);
            _beats.Remove(oldBeat.Key);
        }

        // Update the remaining beats
        foreach (var position in positions)
        {
            // Get the beat object so we can update its position
            GameObject beat;
            // If we already have an object for that beat use that...
            if (_beats.ContainsKey(position.Beat))
            {
                beat = _beats[position.Beat];
            }
            // Otherwise create one
            else
            {
                beat = Instantiate(BeatPrefab);
                _beats.Add(position.Beat, beat);
            }
            // Set the beat's position
            beat.transform.position = Vector3.Lerp(startPos, endPos, position.NormalizedPosition);
        }
    }

    private List<GameObject> GetBeatsInRange(float successRange, float currentTime, Dictionary<float, GameObject> beats)
    {
        var beatsInRange = new List<GameObject>();
        foreach (var beatEntry in beats)
        {
            if (beatEntry.Key - currentTime <= successRange) beatsInRange.Add(beatEntry.Value);
        }
        return beatsInRange;
    }

    // Reset the song timer and clear out any existing objects
    private void Reset()
    {
        _current = 0;
        ClearBeats();
    }

    private struct BeatPosition
    {
        // The number of the beat (since these should be unique we'll use them as the identifier for the beat)
        public float Beat;

        // The normalized position of the beat
        public float NormalizedPosition;
    }

    private List<BeatPosition> GetBeatPositions(float currentTime, float interval, List<float> song)
    {
        var beatPositions = new List<BeatPosition>();

        var start = currentTime;
        var end = currentTime + interval;

        // If we are past the end of the song bail out
        var lastBeat = song[song.Count - 1];
        if (lastBeat < start) return beatPositions;

        // "fast forward" to where you are in the sequence
        var i = 0;
        for (; i < song.Count; i++)
        {
            if (Song[i] >= start)
            {
                break;
            }
        }

        // calculate the positions
        for (var j = i; j < song.Count; j++)
        {
            var beat = song[j];
            if (beat > end) break;
            // normalize the position relative to the visible interval
            var pos = (beat - start) / interval;
            beatPositions.Add(new BeatPosition { Beat = beat, NormalizedPosition = pos });
        }

        return beatPositions;
    }

    private void ClearBeats()
    {
        foreach (var beatEntry in _beats)
        {
            Destroy(beatEntry.Value);
        }
        _beats.Clear();
    }
}