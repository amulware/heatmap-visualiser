﻿using amulware.Graphics;
using Bearded.Utilities.Collections;
using Bearded.Utilities.SpaceTime;
using OpenTK;

namespace Game
{
    sealed class GameState
    {
        private readonly DeletableObjectList<GameObject> gameObjects = new DeletableObjectList<GameObject>();
        private Instant time = Instant.Zero;



        Connection connection;
        public Instant Time { get { return this.time; } }

        public GameState()
        {
            for (int i = 0; i < 5; i++)
            {
                //new RandomAgent(this);
            }

            this.connection = new Connection(this);
        }

        public void Add(GameObject gameObject)
        {
            this.gameObjects.Add(gameObject);
        }

        public void Update(UpdateEventArgs args)
        {
            var elapsedTime = new TimeSpan(args.ElapsedTimeInS);

            this.time += elapsedTime;

            this.connection.Update();


            foreach (var gameObject in this.gameObjects)
            {
                gameObject.Update(elapsedTime);
            }
        }

        public void Render()
        {
            foreach (var gameObject in this.gameObjects)
            {
                gameObject.Draw();
            }
        }
    }
}