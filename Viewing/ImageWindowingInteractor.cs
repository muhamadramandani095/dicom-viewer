﻿using RenderEngine;
using System;
using System.Windows;

namespace Viewing
{
    public class ImageWindowingInteractor : IMouseInteractor
    {
        private bool isDown;

        private Point beginPosition;
        private double beginWidth;
        private double beginLevel;

        public ImageVisual ImageVisual { get; set; }

        public void MouseDown(Point position, Viewport viewport)
        {
            isDown = true;

            beginLevel = ImageVisual.GetWindowLevel();
            beginWidth = ImageVisual.GetWindowWidth();
            beginPosition = position;
        }

        public bool MouseMove(Point position, Viewport viewport)
        {
            if (!isDown) { return false; }

            var delta = position - beginPosition;
            var windowWidth = Math.Min(Math.Max(0, beginWidth + delta.X), 2000);
            var windowLevel = Math.Min(Math.Max(-1000, beginLevel + delta.Y), 2000);
            ImageVisual.SetWindowing(windowLevel, windowWidth);
            return true;
        }

        public void MouseUp(Point position, Viewport viewport)
        {
            isDown = false;
        }
    }
}
