﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace POS.Classes
{
    class Animations
    {
        public static TranslateTransform borderAnimation(int anim, Border control, Boolean Property)
        {
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = anim;
            myDoubleAnimation.Duration = TimeSpan.FromMilliseconds(500);
        
            TranslateTransform translateTransform = new TranslateTransform();
            if (Property)
            {
                translateTransform.BeginAnimation(TranslateTransform.XProperty, myDoubleAnimation);
            }
            else
                translateTransform.BeginAnimation(TranslateTransform.YProperty, myDoubleAnimation);
            return translateTransform;

        }

    }
}