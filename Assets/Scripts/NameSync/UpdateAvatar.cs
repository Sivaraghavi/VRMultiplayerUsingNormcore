using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using System;
using UnityEngine.UI;

namespace Name
{

public class UpdateAvatar : MonoBehaviour
{
        private RealtimeAvatarManager realtimeAvatarManager;
        private RealtimeAvatar realtimeAvatar;
        private string avatarName;

        private void Awake()
        {
            realtimeAvatarManager = GetComponent<RealtimeAvatarManager>();
        }

        private void OnEnable()
        {
            realtimeAvatarManager.avatarCreated += AvatarCreated;
        }

        private void AvatarCreated(RealtimeAvatarManager avatarManager, RealtimeAvatar avatar, bool isLocalAvatar)
        {
           if(isLocalAvatar)
            {
                realtimeAvatar = avatar;
            }
        }

        public void SaveLocalPlayerName(Text nameField) { 
            avatarName = nameField.text;
            realtimeAvatar.GetComponentInChildren<NameSync>().SetText(avatarName);
        }
    }
}
